using Operando_AdministrationConsole.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public string JobName { get; set; }
        public string Description { get; set; }
        public string CurrentVersionNumber { get; set; }
        public string DefinitionLocation { get; set; }
        public string CostPerExecution { get; set; }
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
    {
        public string ExecutionDate { get; set; }
        public string VersionNumber { get; set; }
        public string OspScheduled { get; set; }
        public string DownloadLink { get; set; }
    }

    public class BdaSchedule
    {
        public string OspScheduled { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string RepeatIntervalUnit { get; set; }
        public string RepeatIntervalValue { get; set; }
        public string RepeatOn { get; set; }
        public string StoragePeriod { get; set; }
    }
}