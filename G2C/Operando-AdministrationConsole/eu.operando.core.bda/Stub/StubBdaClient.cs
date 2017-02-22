

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
    }
}
