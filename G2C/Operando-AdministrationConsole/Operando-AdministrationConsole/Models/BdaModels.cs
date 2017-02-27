using System;
using Operando_AdministrationConsole.Helper;
using System.Collections.Generic;
using System.Linq;
using eu.operando.common.Entities;
using eu.operando.core.bda.Model;

namespace Operando_AdministrationConsole.Models
{
    public class BdaPageModel
    {
        public List<BdaJob> Jobs { get; set; }

        public List<string> Osps => Jobs?.SelectMany(_ => _.Osps).Distinct().ToList();

        /*public List<BdaExecution> Executions
        {
        }*/
    }

    public class BdaJob
    {
        /// <summary>
        /// Default Ctor required for MVC serialization
        /// </summary>
        public BdaJob()
        {
            
        }

        public BdaJob(Job job)
        {
            JobId = job.Id;
            JobName = job.JobName;
            Description = job.Description;
            CurrentVersionNumber = job.CurrentVersionNumber;
            DefinitionLocation = job.DefinitionLocation;
            CostPerExecution = job.CostPerExecution;
            Osps = job.Osps;
            Schedules = job.Schedules.Select(_ => new BdaSchedule(_)).ToList();
            Executions = job.Executions.Select(_ => new BdaExecution(_)).ToList();
        }

        public string JobId { get; set; }

        public string JobName { get; set; }
        public string Description { get; set; }
        public string CurrentVersionNumber { get; set; }
        public string DefinitionLocation { get; set; }
        public Money CostPerExecution { get; set; }
        public List<string> Osps { get; set; }
        public List<BdaSchedule> Schedules { get; set; }
        public List<BdaExecution> Executions { get; set; }

        public string DetermineDateMostRecentExecution()
        {
            string dateMostRecentExecution = "";
            for (int i = 0; i < Executions.Count; i++)
            {
                BdaExecution execution = Executions[i];
                string executionDate = execution.ExecutionDate;
                bool moreRecentExecutionDate = string.Compare(executionDate, dateMostRecentExecution) > 0;
                if (i == 0)
                {
                    dateMostRecentExecution = execution.ExecutionDate;
                }
                else if (moreRecentExecutionDate)
                {
                    dateMostRecentExecution = executionDate;
                }
            }
            return dateMostRecentExecution;
        }

        public string DetermineDateNextExecution()
        {
            return StaticStrings.NotImplemented;
            /*string dateNextExecution = "";
            for (int i = 0; i < Schedules.Count; i++)
            {
                BdaSchedule schedule = Schedules[i];
                string executionDate = schedule.;
                bool moreRecentExecutionDate = string.Compare(executionDate, dateNextExecution) > 0;
                if (i == 0)
                {
                    dateNextExecution = schedule.ExecutionDate;
                }
                else if (moreRecentExecutionDate)
                {
                    dateNextExecution = executionDate;
                }
            }
            return dateNextExecution;*/
        }
    }

    public class BdaExecution
    { /// <summary>
      /// Default Ctor required for MVC serialization
      /// </summary>
        public BdaExecution()
        {
        }

        public BdaExecution(Execution execution)
        {
            Id = execution.Id;
            JobId = execution.JobId;
            OspScheduled = execution.OspScheduled;
            ExecutionDate = execution.ExecutionDate.ToString();
            VersionNumber = execution.VersionNumber;
            DownloadLink = execution.DownloadLink;
        }

        public string Id { get; set; }
        public string JobId { get; set; }
        public string ExecutionDate { get; set; }
        public string VersionNumber { get; set; }
        public string OspScheduled { get; set; }
        public string DownloadLink { get; set; }
    }

    public class BdaSchedule
    {
        /// <summary>
        /// Default Ctor required for MVC serialization
        /// </summary>
        public BdaSchedule()
        {
            
        }

        public BdaSchedule(Schedule schedule)
        {
            Id = schedule.Id;
            JobId = schedule.JobId;
            OspScheduled = schedule.OspScheduled;
            StartTime = schedule.StartTime;
            RepeatIntervalDays = schedule.RepeatInterval.Days;
        }

        public string Id { get; set; }
        public string JobId { get; set; }
        public string OspScheduled { get; set; }
        public TimeSpan StartTime { get; set; }
        public double RepeatIntervalDays { get; set; }
    }
}