using System;

namespace Operando_AdministrationConsole.Models.DashboardModels
{
    public class NotificationsModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime TimeStamp { get; set; }

        public NotificationsModel(DataAccessLog log)
        {
            Title = log.title;
            Description = log.description;
            TimeStamp = log.logDate;
        }
    }
}