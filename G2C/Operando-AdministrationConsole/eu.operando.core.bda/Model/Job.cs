using System.Collections.Generic;
using eu.operando.common.Entities;

namespace eu.operando.core.bda.Model
{
    public class Job
    {
        /// <summary>
        /// The unique identifier for this BDA Job.
        /// </summary>
        /// <remarks>
        /// This should be a Java UUID, but is stored as a string in C# to avoid interop complexities.
        /// </remarks>
        public string Id { get; set; }
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
            // TODO
            return "Not implemented";
        }

        public string DetermineDateNextExecution()
        {
            // TODO
            return "Not implemented";
        }
    }
}