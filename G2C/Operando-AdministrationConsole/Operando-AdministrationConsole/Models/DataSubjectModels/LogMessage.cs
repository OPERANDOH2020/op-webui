using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class LogMessage
    {
        private const string UserIdToReplace = "141";
        private const string RoleToReplaceWith = "Volunteer Link-Up";

        private static readonly string PhraseWithFieldsRegex = "(.+requested access to your )(.*)(" + Regex.Escape(".") + ".+)";
        private const string GetFieldsRegex = "$2";
        private const string ReplaceFieldsRegexPrefix = "$1";
        private static readonly string ReplaceFieldsRegexSuffix = "$3";

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

        public string Message { get; private set; }
        public IEnumerable<string> FieldsInMessage {
            get
            {
                string fieldsInMessageStr = Regex.Replace(Message, PhraseWithFieldsRegex, GetFieldsRegex);
                IEnumerable<string> fieldsInMessage = fieldsInMessageStr.Split(',');
                return fieldsInMessage;
            }
        }

        public LogMessage(DataAccessLog entity)
        {
            Message = entity.description;
        }

        public void ReplaceUserIdsWithRoles()
        {
            Message = Message.Replace(UserIdToReplace, RoleToReplaceWith);
        }

        public void HideUnwantedFields()
        {
            IEnumerable<string> fieldsToShow = FieldsInMessage.Where(field => !FieldsNotToShow.Contains(field));
            string fieldsToShowStr = String.Join(", ", fieldsToShow);
            string messageWithOnlyFieldsToShow = Regex.Replace(Message, PhraseWithFieldsRegex,
                ReplaceFieldsRegexPrefix + fieldsToShowStr + ReplaceFieldsRegexSuffix);
            Message = messageWithOnlyFieldsToShow;
        }
    }
}