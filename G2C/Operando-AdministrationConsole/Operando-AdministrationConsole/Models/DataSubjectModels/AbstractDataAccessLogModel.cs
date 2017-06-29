using System;
using System.Collections.Generic;
using System.Linq;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public abstract class AbstractDataAccessLogModel
    {
        protected const string UserIdToReplace = "141";
        protected const string RoleToReplaceWith = "Volunteer Link-Up";

        private static readonly IList<string> FieldsNotToShow = new List<string>
        {
            "ActivationDate",
            "ActivationUrl",
            "Address_Id",
            "AmiUserId",
            "Availability_Id",
            "ConfidentialNote_Id",
            "DateOfBirth",
            "GenderType",
            "Gender_Value",
            "OtherGender",
            "Preferences_Id",
            "ReferrerType_Value",
            "UnsuccessfulReason_Id",
            "VolunteerOrganisation",
            "VolunteerOrganisation_Id"
        };

        public bool AccessGranted;
        public DateTime LogDate;
        public string Message => _logMessage.Message;
        private readonly LogMessage _logMessage;

        public AbstractDataAccessLogModel(DataAccessLog entity)
        {
            AccessGranted = ParseAccessGranted(entity);
            LogDate = entity.logDate;
            _logMessage = ParseMessage(entity);
        }

        private static LogMessage ParseMessage(DataAccessLog entity)
        {
            var logMessage = new LogMessage(entity);
            logMessage.ReplaceUserIdsWithRoles(UserIdToReplace, RoleToReplaceWith);
            logMessage.HideUnwantedFields(FieldsNotToShow);
            logMessage.MakeFieldnamesUserFriendly();

            return logMessage;
        }

        private static bool ParseAccessGranted(DataAccessLog entity)
        {
            bool accessGranted;
            if (entity.title == DataAccessLog.AccessDeniedTitle)
            {
                accessGranted = false;
            }
            else if (entity.title == DataAccessLog.AccessGrantedTitle)
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

        public bool ShouldBeShownOnDashboard()
        {
            IEnumerable<string> fieldsInMessage = _logMessage.FieldsRequested;
            return fieldsInMessage.Any(field => !string.IsNullOrEmpty(field));
        }
    }
}