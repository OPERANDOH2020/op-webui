using System;
using eu.operando.core.bda.Model;

namespace Operando_AdministrationConsole.Models.DashboardModels.WidgetModels
{
    public class DataExtractsModel
    {
        public DateTime ExtractionDate { get; set; }
        public string JobName { get; set; }
        public string Version { get; set; }
        public string DownloadUrl { get; set; }

        public DataExtractsModel(Execution execution)
        {
            ExtractionDate = execution.ExecutionDate;
            Version = execution.VersionNumber;
            DownloadUrl = execution.DownloadLink;
        }
    }
}