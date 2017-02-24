
using System;
using System.Collections.Generic;
using eu.operando.common.Entities;
using eu.operando.core.bda.Model;

namespace eu.operando.core.bda.Stub
{
    internal class StubBdaRepository
    {
        public StubBdaRepository()
        {
            SeedData();
        }

        public ICollection<Job> Jobs { get; } = new SynchronizedCollection<Job>();

        public ICollection<Schedule> Schedules { get; } = new SynchronizedCollection<Schedule>();

        public ICollection<Execution> Executions { get; } = new SynchronizedCollection<Execution>();

        private void SeedData()
        {
            for (var index = 0; index < 3; index++)
            {
                var job = SeedJob(index);
                job.Schedules.Add(SeedSchedule(index));
                job.Schedules.Add(SeedSchedule(index * 10));
                job.Executions.Add(SeedExecution(index));
                job.Executions.Add(SeedExecution(index * 10));
            }
        }

        private Job SeedJob(int index)
        {
            var job = new Job
            {
                Id = Guid.NewGuid().ToString(),
                JobName = $"Job {index}",
                Description = $"Description {index}",
                DefinitionLocation = $"http://www.example.com/joblocation/{index}",
                CostPerExecution = new Money
                {
                    Currency = Money.CurrencyCode.EUR,
                    Value = index * 10.0m
                },
                Osps = new List<string> { "OCC", "ITI" },
                Schedules = new List<Schedule>(),
                Executions = new List<Execution>()
            };
            Jobs.Add(job);

            return job;
        }

        private Schedule SeedSchedule(int index)
        {
            var arbitraryTimespan = TimeSpan.FromHours(index);

            var schedule = new Schedule
            {
                Id = Guid.NewGuid().ToString(),
                OspScheduled = "OCC",
                StartDate = DateTime.UtcNow.Date,
                RepeatInterval = arbitraryTimespan,
                RepeatOn = true.ToString(),
                StoragePeriod = arbitraryTimespan
            };

            Schedules.Add(schedule);

            return schedule;
        }

        private Execution SeedExecution(int index)
        {
            var arbitraryDate = DateTime.UtcNow.AddDays(-index);

            var execution = new Execution
            {
                ExecutionDate = arbitraryDate,
                OspScheduled = "OCC",
                VersionNumber = new Version(0, index),
                DownloadLink = $"http://www.example.com/execution/download/{index}"
            };

            Executions.Add(execution);

            return execution;
        }

    }
}
