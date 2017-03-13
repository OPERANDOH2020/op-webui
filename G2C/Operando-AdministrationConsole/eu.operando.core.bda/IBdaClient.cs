using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eu.operando.core.bda.Model;
using JetBrains.Annotations;

namespace eu.operando.core.bda
{
    public interface IBdaClient
    {
        /// <summary>
        /// Get the jobs.
        /// </summary>
        /// <param name="osp">If provided, filter on the jobs for the specified OSP</param>
        /// <returns></returns>
        [ItemNotNull]
        Task<ICollection<Job>> GetJobsAsync([CanBeNull] string osp = null);

        /// <summary>
        /// Get the job for the specified Id. If no job exists with that id, return null
        /// </summary>
        [ItemCanBeNull]
        Task<Job> GetJobByIdAsync([NotNull] string jobId);

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

        [NotNull]
        Task RequestNewBdaExtractionAsync([NotNull] ExtractionRequest extractionRequest);

        /// <summary>
        /// Get Extraction Requests that are waiting to be actioned by (e.g.) a PSP Analyst
        /// </summary>
        /// <returns></returns>
        [ItemNotNull]
        Task<IEnumerable<ExtractionRequest>> GetUnfulfilledBdaExtractionRequestsAsync();

        /// <summary>
        /// Get the schedule for the specified Id. If no schedule exists with that id, return null
        /// </summary>
        [ItemCanBeNull]
        Task<Schedule> GetScheduleByIdAsync([NotNull] string scheduleId);

        [NotNull]
        Task AddScheduleAsync([NotNull] Schedule schedule);

        [NotNull]
        Task UpdateScheduleAsync([NotNull] Schedule schedule);

        [NotNull]
        Task DeleteScheduleAsync([NotNull] Schedule schedule);

        /// <summary>
        /// Get the latest extractions executed for the specified osp
        /// </summary>
        /// <param name="osp">the osp the extractions have been created for</param>
        /// <param name="count">the maximum number of results to return</param>
        /// <returns></returns>
        [ItemNotNull]
        Task<IEnumerable<Execution>> GetLatestExecutionsForOspAsync([NotNull] string osp, int count);
    }
}