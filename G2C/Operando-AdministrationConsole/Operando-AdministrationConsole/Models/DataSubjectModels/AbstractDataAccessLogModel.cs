using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class AbstractDataAccessLogModel
    {
        public bool AccessGranted;
        public DateTime LogDate;
        public string Message => _logMessage.Message;
        private readonly LogMessage _logMessage;

        public AbstractDataAccessLogModel(DataAccessLog entity)
        {
            AccessGranted = ParseAccessGranted(entity);
            LogDate = entity.logDate;
            _logMessage = ParseMessage(entity);
        }

        private static LogMessage ParseMessage(DataAccessLog entity)
        {
            var logMessage = new LogMessage(entity);
            logMessage.ReplaceUserIdsWithRoles();
            logMessage.HideUnwantedFields();

            return logMessage;
        }

        private static bool ParseAccessGranted(DataAccessLog entity)
        {
            bool accessGranted;
            if (entity.title.Equals(DataAccessLog.AccessDeniedTitle))
            {
                accessGranted = false;
            }
            else if (entity.title.Equals(DataAccessLog.AccessGrantedTitle))
            {
                accessGranted = true;
            }
            else
            {
                // It would be preferable to do validation when the log is created, rather than when interpreting the log.
                // Since we don't have control over the code that accepts logs, or does the logging, this is the next-best thing.
                throw new ArgumentException("The data access log has an invalid title, so the AccessGranted property cannot be parsed.");
            }
            return accessGranted;
        }

        public bool ShouldBeShownOnDashboard()
        {
            IEnumerable<string> fieldsInMessage = _logMessage.FieldsInMessage;
            return fieldsInMessage.Any(field => !field.IsEmpty());
        }
    }
}