using System;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class AbstractDataAccessLogModel
    {
        protected const string UserIdToReplace = "141";
        protected const string RoleToReplaceWith = "Volunteer Link-Up";

        public bool AccessGranted;
        public DateTime LogDate;
        public string Message;

        public AbstractDataAccessLogModel(DataAccessLog entity)
        {
            AccessGranted = ParseAccessGranted(entity);
            LogDate = entity.logDate;
            Message = ParseMessage(entity);
        }

        private static string ParseMessage(DataAccessLog entity)
        {
            return entity.description.Replace(UserIdToReplace, RoleToReplaceWith);
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
                throw new ArgumentException("The data access log has an invalid title, so the AccessGranted property cannot be parsed.");
            }
            return accessGranted;
        }
    }
}