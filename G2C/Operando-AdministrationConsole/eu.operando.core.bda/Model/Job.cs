using System;
using System.Collections.Generic;
using eu.operando.common.Entities;

namespace eu.operando.core.bda.Model
{
    public class Job
    {
        public Guid Id { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public string CurrentVersionNumber { get; set; }
        public string DefinitionLocation { get; set; }
        public Money CostPerExecution { get; set; }
        public List<string> Osps { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<Execution> Executions { get; set; }

        public string DetermineDateMostRecentExecution()
        {
            string dateMostRecentExecution = "";
            for (int i = 0; i < Executions.Count; i++)
            {
                Execution execution = Executions[i];
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
            // TODO
            return "Not implemented";
        }
    }
}