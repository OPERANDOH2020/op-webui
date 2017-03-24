using System;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DashboardModels.WidgetModels
{
    public class NotificationsWidgetModel
    {
        public string Description { get; set; }

        public DateTime TimeStamp { get; set; }

        public NotificationsWidgetModel(DataAccessLog log)
        {
            Description = log.description;
            TimeStamp = log.logDate;
        }
    }
}