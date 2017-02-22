using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eu.operando.core.bda.Model;
using JetBrains.Annotations;

namespace eu.operando.core.bda
{
    public interface IBdaClient
    {
        [NotNull]
        Task<ICollection<Job>> GetJobsAsync(string osp);

        /// <summary>
        /// Get the job for the specified Id. If no job exists with that id, return null
        /// </summary>
        [ItemCanBeNull]
        Task<Job> GetJobByIdAsync(Guid jobId);

        Task AddJobAsync(Job job);
    }
}