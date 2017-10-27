using System;
using System.Collections.Generic;
using System.Linq;
using eu.operando.core.ldb.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Operando_AdministrationConsole.Helper;
using Operando_AdministrationConsole.Models.DataSubjectModels;

namespace Operando_AdministrationConsoleTests.Helper
{
    [TestClass]
    public class DataAccessLogAggregatorTests
    {
        private DataAccessLogAggregator _aggregator;
        private INiceStringConverter _stringConverter;

        [TestInitialize]
        public void Initialise()
        {
            _aggregator = new DataAccessLogAggregator();
            _stringConverter = new MockStringConverter();
        }

        [TestMethod]
        public void Aggregate_DuplicateRequests_DontRepeat()
        {
            // Arrange
            var logs = new List<DataAccessLogModel>
            {
                CreateModel("osp", "req", new []{"thing1"}, new [] {"thing2"}, new DateTime(2000, 1, 1, 1, 1, 1)),
                CreateModel("osp", "req", new []{"thing1"}, new [] {"thing3"}, new DateTime(2000, 1, 1, 2, 1, 1)),
                CreateModel("osp", "req", new []{"thing4"}, new [] {"thing3"}, new DateTime(2000, 1, 1, 3, 1, 1))
            };

            // Act
            var expected = new List<DataAccessLogModel>
            {
                CreateModel("osp", "req", new []{"thing1", "thing4"}, new [] {"thing2", "thing3"}, new DateTime(2000, 1, 1, 1, 1, 1), new DateTime(2000, 1, 1, 3, 1, 1))
            };

            var actual = _aggregator.Aggregate(logs).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Aggregate_DifferentDays_DontAggregate()
        {
            // Arrange
            var logs = new List<DataAccessLogModel>
            {
                CreateModel("osp", "req", new []{"thing1"}, new [] {"thing2"}, new DateTime(2000, 1, 1, 1, 1, 1)),
                CreateModel("osp", "req", new []{"thing3"}, new [] {"thing4"}, new DateTime(2000, 1, 2, 2, 1, 1)),
                CreateModel("osp", "req", new []{"thing5"}, new [] {"thing6"}, new DateTime(2000, 1, 2, 3, 1, 1))
            };

            // Act
            var expected = new List<DataAccessLogModel>
            {
                CreateModel("osp", "req", new []{"thing1"}, new [] {"thing2"}, new DateTime(2000, 1, 1, 1, 1, 1)),
                CreateModel("osp", "req", new []{"thing3", "thing5"}, new [] {"thing4", "thing6"}, new DateTime(2000, 1, 2, 2, 1, 1), new DateTime(2000, 1, 2, 3, 1, 1))
            };

            var actual = _aggregator.Aggregate(logs).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Aggregate_DifferentOsps_DontAggregate()
        {
            // Arrange
            var logs = new List<DataAccessLogModel>
            {
                CreateModel("ospB", "req", new []{"thing3"}, new [] {"thing4"}, new DateTime(2000, 1, 1, 1, 1, 1)),
                CreateModel("ospA", "req", new []{"thing1"}, new [] {"thing2"}, new DateTime(2000, 1, 1, 2, 1, 1)),
                CreateModel("ospB", "req", new []{"thing5"}, new [] {"thing6"}, new DateTime(2000, 1, 1, 3, 1, 1))
            };

            // Act
            var expected = new List<DataAccessLogModel>
            {
                CreateModel("ospA", "req", new []{"thing1"}, new [] {"thing2"}, new DateTime(2000, 1, 1, 2, 1, 1)),
                CreateModel("ospB", "req", new []{"thing3", "thing5"}, new [] {"thing4", "thing6"}, new DateTime(2000, 1, 1, 1, 1, 1), new DateTime(2000, 1, 1, 3, 1, 1))
            };

            var actual = _aggregator.Aggregate(logs).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Aggregate_DifferentRequesters_DontAggregate()
        {
            // Arrange
            var logs = new List<DataAccessLogModel>
            {
                CreateModel("osp", "reqB", new []{"thing3"}, new [] {"thing4"}, new DateTime(2000, 1, 1, 1, 1, 1)),
                CreateModel("osp", "reqA", new []{"thing1"}, new [] {"thing2"}, new DateTime(2000, 1, 1, 2, 1, 1)),
                CreateModel("osp", "reqB", new []{"thing5"}, new [] {"thing6"}, new DateTime(2000, 1, 1, 3, 1, 1))
            };

            // Act
            var expected = new List<DataAccessLogModel>
            {
                CreateModel("osp", "reqA", new []{"thing1"}, new [] {"thing2"}, new DateTime(2000, 1, 1, 2, 1, 1)),
                CreateModel("osp", "reqB", new []{"thing3", "thing5"}, new [] {"thing4", "thing6"}, new DateTime(2000, 1, 1, 1, 1, 1), new DateTime(2000, 1, 1, 3, 1, 1))
            };

            var actual = _aggregator.Aggregate(logs).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Aggregate_ClashingRequests_DontAggregate()
        {
            // Arrange
            var logs = new List<DataAccessLogModel>
            {
                CreateModel("osp", "req", new []{"thing1"}, new [] {"thing2"}, new DateTime(2000, 1, 1, 1, 1, 1)),
                CreateModel("osp", "req", new []{"thing2"}, new [] {"thing1"}, new DateTime(2000, 1, 1, 2, 1, 1)),
                CreateModel("osp", "req", new []{"thing3"}, new [] {"thing4"}, new DateTime(2000, 1, 1, 3, 1, 1)),
                CreateModel("osp", "req", new []{"thing4"}, new [] {"thing3"}, new DateTime(2000, 1, 1, 4, 1, 1))
            };

            // Act
            var expected = new List<DataAccessLogModel>
            {
                CreateModel("osp", "req", new []{"thing1"}, new [] {"thing2"}, new DateTime(2000, 1, 1, 1, 1, 1)),
                CreateModel("osp", "req", new []{"thing2", "thing3"}, new [] {"thing1", "thing4"}, new DateTime(2000, 1, 1, 2, 1, 1), new DateTime(2000, 1, 1, 3, 1, 1)),
                CreateModel("osp", "req", new []{"thing4"}, new [] {"thing3"}, new DateTime(2000, 1, 1, 4, 1, 1))
            };

            var actual = _aggregator.Aggregate(logs).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Aggregate_Sorting_ByEndDateIfApplicableElseStartDate()
        {
            // Arrange
            var logs = new List<DataAccessLogModel>
            {
                CreateModel("osp", "req1", new []{"thing1"}, new string[0], new DateTime(2000, 1, 1, 1, 1, 1)),
                CreateModel("osp", "req2", new []{"thing1"}, new string[0], new DateTime(2000, 1, 1, 2, 1, 1)),
                CreateModel("osp", "req2", new []{"thing1"}, new string[0], new DateTime(2000, 1, 1, 4, 1, 1)),
                CreateModel("osp", "req3", new []{"thing1"}, new string[0], new DateTime(2000, 1, 1, 3, 1, 1)),
                CreateModel("osp", "req1", new []{"thing1"}, new string[0], new DateTime(2000, 1, 1, 5, 1, 1))
            };

            // Act
            var expected = new List<DataAccessLogModel>
            {
                CreateModel("osp", "req3", new []{"thing1"}, new string[0], new DateTime(2000, 1, 1, 3, 1, 1)),
                CreateModel("osp", "req2", new []{"thing1"}, new string[0], new DateTime(2000, 1, 1, 2, 1, 1), new DateTime(2000, 1, 1, 4, 1, 1)),
                CreateModel("osp", "req1", new []{"thing1"}, new string[0], new DateTime(2000, 1, 1, 1, 1, 1), new DateTime(2000, 1, 1, 5, 1, 1))
            };

            var actual = _aggregator.Aggregate(logs).ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        private DataAccessLogModel CreateModel(string osp, string requester, string[] accepted, string[] denied, DateTime logStart, DateTime? logEnd = null)
        {
            var entity = new DataAccessLog
            {
                arrayGrantedFields = accepted,
                arrayRequestedFields = accepted.Union(denied).ToArray(),
                ospId = osp,
                requesterId = requester,
                logDate = logStart

            };
            return new DataAccessLogModel(entity, _stringConverter)
            {
                LogDateEnd = logEnd
            };
        }

        private class MockStringConverter : INiceStringConverter
        {
            public string NiceAccessorNameOrDefault(string accessor)
            {
                return accessor;
            }

            public string NiceResourceNameOrDefault(string resource)
            {
                return resource;
            }

            public string NiceActionNameOrDefault(string action)
            {
                return action;
            }
        }
    }
}
