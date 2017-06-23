using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class DataAccessLogModel
    {
        public bool AccessGranted;
        public DateTime LogDate;
        public string RequesterType;
        public string Title;
        public string Description;
        public string RequesterId;

        public DataAccessLogModel(DataAccessLog entity)
        {
            AccessGranted = ParseAccessGranted(entity);
            LogDate = entity.logDate;
            RequesterType = entity.requesterType;
            Title = entity.title;
            Description = entity.description;
            RequesterId = entity.requesterId;
        }

        private bool ParseAccessGranted(DataAccessLog entity)
        {
            bool accessGranted;
            if (entity.title.Equals(DataAccessLog.AccessDeniedTitle))
            {
                accessGranted = false;
            }
            else if (entity.title.Equals(DataAccessLog.AccessGrantedTitle))
            {
                accessGranted = true;
            }
            else
            {
                // It would be preferable to do validation when the log is created, rather than when interpreting the log.
                // Since we don't have control over the code that accepts logs, or does the logging, this is the next-best thing.
                throw new ArgumentException("The data access log has an invalid title, so the ");
            }
            return accessGranted;
        }
    }
}