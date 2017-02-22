using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eu.operando.core.bda.Model;
using JetBrains.Annotations;

namespace eu.operando.core.bda
{
    public interface IBdaClient
    {
        [ItemNotNull]
        Task<ICollection<Job>> GetJobsAsync(string osp);

        /// <summary>
        /// Get the job for the specified Id. If no job exists with that id, return null
        /// </summary>
        [ItemCanBeNull]
        Task<Job> GetJobByIdAsync(Guid jobId);

        /// <summary>
        /// Create a big data job
        /// </summary>
        [NotNull]
        Task AddJobAsync([NotNull] Job job);

        /// <summary>
        /// Update the job
        /// </summary>
        /// <exception cref="InvalidOperationException">If a job with the specified ID does not exist</exception>
        [NotNull]
        Task UpdateJobAsync([NotNull] Job job);
    }
}