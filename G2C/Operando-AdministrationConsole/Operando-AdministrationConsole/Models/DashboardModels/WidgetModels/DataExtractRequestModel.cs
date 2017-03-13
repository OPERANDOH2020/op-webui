using System;

namespace Operando_AdministrationConsole.Models.DashboardModels.WidgetModels
{
    public class DataExtractRequestModel
    {
        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public string RequesterOsp { get; set; }
        public string RequestDetail { get; set; }
        public DateTime RequestDate { get; set; }
    }
}