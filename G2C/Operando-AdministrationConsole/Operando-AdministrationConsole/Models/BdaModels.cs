using Operando_AdministrationConsole.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eu.operando.common.Entities;
using eu.operando.core.bda.Model;

namespace Operando_AdministrationConsole.Models
{
    public class BdaPageModel
    {
        public List<BdaJob> Jobs { get; set; }

        public List<string> Osps
        {
            get
            {
                List<string> ospsUnique = new List<string>();
                foreach (BdaJob job in Jobs)
                {
                    ospsUnique.Union(job.Osps);
                }
                return ospsUnique;
            }
        }

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
            JobName = job.JobName;
            Description = job.Description;
            CurrentVersionNumber = job.CurrentVersionNumber;
            DefinitionLocation = job.DefinitionLocation;
            CostPerExecution = job.CostPerExecution;
            Osps = job.Osps;
            Schedules = job.Schedules.Select(_ => new BdaSchedule(_)).ToList();
            Executions = job.Executions.Select(_ => new BdaExecution(_)).ToList();
        }

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
            OspScheduled = execution.OspScheduled;
            ExecutionDate = execution.ExecutionDate;
            VersionNumber = execution.VersionNumber;
            DownloadLink = execution.DownloadLink;
        }
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
            OspScheduled = schedule.OspScheduled;
            StartDate = schedule.StartDate;
            StartTime = schedule.StartTime;
            RepeatIntervalUnit = schedule.RepeatIntervalUnit;
            RepeatIntervalValue = schedule.RepeatIntervalValue;
            StoragePeriod = schedule.StoragePeriod;
        }

        public string OspScheduled { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string RepeatIntervalUnit { get; set; }
        public string RepeatIntervalValue { get; set; }
        public string RepeatOn { get; set; }
        public string StoragePeriod { get; set; }
    }
}