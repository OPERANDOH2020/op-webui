using System;

namespace eu.operando.core.bda.Model
{
    public class Execution
    {
        public string Id { get; set; }
        public string JobId { get; set; }
        public DateTime ExecutionDate { get; set; }
        public Version VersionNumber { get; set; }
        public string OspScheduled { get; set; }
        public string DownloadLink { get; set; }
    }
}