using System;

namespace eu.operando.core.bda.Model
{
    public class Execution
    {
        public DateTime ExecutionDate { get; set; }
        public Version VersionNumber { get; set; }
        public string OspScheduled { get; set; }
        public string DownloadLink { get; set; }
    }
}