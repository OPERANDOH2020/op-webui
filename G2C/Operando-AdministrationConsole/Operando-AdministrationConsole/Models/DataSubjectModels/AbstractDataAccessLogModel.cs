using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class AbstractDataAccessLogModel
    {
        private static readonly string PhraseWithFieldsRegex = "(.+requested access to your )(.+)(" + Regex.Escape(".") + ".+)";
        private const string GetFieldsRegex = "$2";
        private const string ReplaceFieldsRegexPrefix = "$1";
        private static readonly string ReplaceFieldsRegexSuffix = "$3";

        protected const string UserIdToReplace = "141";
        protected const string RoleToReplaceWith = "Volunteer Link-Up";

        public bool AccessGranted;
        public DateTime LogDate;
        public string Message;

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

        public AbstractDataAccessLogModel(DataAccessLog entity)
        {
            AccessGranted = ParseAccessGranted(entity);
            LogDate = entity.logDate;
            Message = ParseMessage(entity);
        }

        private static string ParseMessage(DataAccessLog entity)
        {
            string entityDescription = entity.description;
            string messageWithRole = entityDescription.Replace(UserIdToReplace, RoleToReplaceWith);

            string fieldsInMessageStr = Regex.Replace(messageWithRole, PhraseWithFieldsRegex, GetFieldsRegex);
            IEnumerable<string> fieldsInMessage = fieldsInMessageStr.Split(',');
            IEnumerable<string> fieldsToShow = fieldsInMessage.Where(field => !FieldsNotToShow.Contains(field));
            string fieldsToShowStr = string.Join(",", fieldsToShow);

            string messageWithoutFieldsNotToShow = Regex.Replace(messageWithRole, PhraseWithFieldsRegex,
                ReplaceFieldsRegexPrefix + fieldsToShowStr + ReplaceFieldsRegexSuffix);

            string message = messageWithoutFieldsNotToShow;
            return message;
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