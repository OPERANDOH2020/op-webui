

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eu.operando.core.bda.Model;
using eu.operando.core.bda.Stub;

// ReSharper disable once CheckNamespace
namespace eu.operando.core.bda
{
    /// <summary>
    /// TODO -- this should be replaced by a real Bda client that talks to a real bda module
    /// </summary>
    public class StubBdaClient : IBdaClient
    {
        private static readonly StubBdaRepository Repository = new StubBdaRepository();

        public Task<ICollection<Job>> GetJobsAsync(string osp)
        {
            ICollection<Job> jobs = Repository.Jobs;

            if (osp != null)
            {
                jobs = jobs.Where(_ => _.Osps.Contains(osp)).ToList();
            }

            return Task.FromResult(jobs);
        }

        public Task<Job> GetJobByIdAsync(string jobId)
        {
            if (jobId == null) throw new ArgumentNullException(nameof(jobId));

            Job job = Repository.Jobs.SingleOrDefault(_ => _.Id == jobId);

            return Task.FromResult(job);
        }

        public Task AddJobAsync(Job job)
        {
            job.Id = Guid.NewGuid().ToString();
            job.Executions = new List<Execution>();
            job.Schedules = new List<Schedule>();

            Repository.Jobs.Add(job);

            // No-op. Should be Task.CompletedTask but that is not available until .NET 4.6 (this is .NET 4.0)
            return Task.FromResult(true);
        }

        public async Task UpdateJobAsync(Job job)
        {
            var repoJob = await GetJobByIdAsync(job.Id);

            if (repoJob == null) throw new ArgumentException($"Job with id {job.Id} does not exist in repository");

            Repository.Jobs.Remove(repoJob);
            Repository.Jobs.Add(job);
        }

        public Task RequestNewBdaExtractionAsync(ExtractionRequest extractionRequest)
        {
            // No-op. Should be Task.CompletedTask but that is not available until .NET 4.6 (this is .NET 4.0)
            return Task.FromResult(true);
        }

        public Task<Schedule> GetScheduleByIdAsync(string scheduleId)
        {
            var schedule = Repository.Schedules.SingleOrDefault(_ => _.Id == scheduleId);

            return Task.FromResult(schedule);
        }

        public async Task AddScheduleAsync(Schedule schedule)
        {
            var job = await GetJobByIdAsync(schedule.JobId);
            
            if (job == null) throw new ArgumentException($"Job with id {schedule.JobId} does not exist in repository");

            schedule.Id = Guid.NewGuid().ToString();

            job.Schedules.Add(schedule);
            Repository.Schedules.Add(schedule);
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            var repoSchedule = await GetScheduleByIdAsync(schedule.Id);

            if (repoSchedule == null) throw new ArgumentException($"Schedule with id {schedule.Id} does not exist in repository");

            Repository.Schedules.Remove(repoSchedule);
            Repository.Schedules.Add(schedule);

            foreach (var job in Repository.Jobs)
            {
                if (job.Schedules.Contains(repoSchedule))
                {
                    job.Schedules.Remove(repoSchedule);
                    job.Schedules.Add(schedule);
                }
            }
        }

        public async Task DeleteScheduleAsync(Schedule schedule)
        {
            if (schedule == null) throw new ArgumentNullException(nameof(schedule));

            var repoSchedule = await GetScheduleByIdAsync(schedule.Id);

            if (repoSchedule == null) throw new ArgumentException($"Schedule with id {schedule.Id} does not exist in repository");

            Repository.Schedules.Remove(repoSchedule);

            foreach (var job in Repository.Jobs)
            {
                if (job.Schedules.Contains(repoSchedule))
                {
                    job.Schedules.Remove(repoSchedule);
                }
            }
        }
    }
}
