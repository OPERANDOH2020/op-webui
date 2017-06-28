using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.WebPages;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class AbstractDataAccessLogModel
    {
        private static readonly string PhraseWithFieldsRegex = "(.+requested access to your )(.*)(" + Regex.Escape(".") + ".+)";
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

        public bool ShouldBeShownOnDashboard()
        {
            IEnumerable<string> fieldsToShow = DetermineFieldsToShow(Message);
            return fieldsToShow.Any(field => !field.IsEmpty());
        }

        private static string ParseMessage(DataAccessLog entity)
        {
            string entityDescription = entity.description;
            string messageWithRole = entityDescription.Replace(UserIdToReplace, RoleToReplaceWith);

            IEnumerable<string> fieldsToShow = DetermineFieldsToShow(messageWithRole);
            string messageWithOnlyFieldsToShow = CreateMessageWithOnlyFieldsToShow(messageWithRole, fieldsToShow);

            string message = messageWithOnlyFieldsToShow;
            return message;
        }

        private static string CreateMessageWithOnlyFieldsToShow(string message, IEnumerable<string> fieldsToShow)
        {
            string fieldsToShowStr = string.Join(", ", fieldsToShow);
            string messageWithoutFieldsNotToShow = Regex.Replace(message, PhraseWithFieldsRegex,
                ReplaceFieldsRegexPrefix + fieldsToShowStr + ReplaceFieldsRegexSuffix);
            return messageWithoutFieldsNotToShow;
        }

        private static IEnumerable<string> DetermineFieldsToShow(string message)
        {
            string fieldsInMessageStr = Regex.Replace(message, PhraseWithFieldsRegex, GetFieldsRegex);
            IEnumerable<string> fieldsInMessage = fieldsInMessageStr.Split(',');
            IEnumerable<string> fieldsToShow = fieldsInMessage.Where(field => !FieldsNotToShow.Contains(field));
            return fieldsToShow;
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