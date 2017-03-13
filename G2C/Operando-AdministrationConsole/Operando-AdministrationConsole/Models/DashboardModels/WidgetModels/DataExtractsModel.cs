using System;

namespace Operando_AdministrationConsole.Models.DashboardModels.WidgetModels
{
    public class DataExtractsModel
    {
        public DateTime ExtractionDate { get; set; }
        public string JobName { get; set; }
        public string Version { get; set; }
        public string DownloadUrl { get; set; }
    }
}