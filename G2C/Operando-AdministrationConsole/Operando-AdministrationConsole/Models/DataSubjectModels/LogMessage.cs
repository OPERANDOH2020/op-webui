using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using eu.operando.core.ldb.Model;
using Operando_AdministrationConsole.Helper;

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
                IEnumerable<string> fieldsInMessageWithSpaces = fieldsInMessageStr.Split(',');
                IEnumerable<string> fieldsInMessage = fieldsInMessageWithSpaces.Select(field => field.Trim());
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
            UpdateFieldsInMessage(fieldsToShow);
        }

        public void MakeFieldnamesUserFriendly()
        {
            IEnumerable<string> fieldsWithNiceNames = FieldsInMessage.Select(AmiDictionaries.NiceResourceNameOrDefault);
            UpdateFieldsInMessage(fieldsWithNiceNames);
        }

        private void UpdateFieldsInMessage(IEnumerable<string> newFields)
        {
            string newFieldsStr = String.Join(", ", newFields);
            string messageWithNewFields = Regex.Replace(Message, PhraseWithFieldsRegex,
                ReplaceFieldsRegexPrefix + newFieldsStr + ReplaceFieldsRegexSuffix);
            Message = messageWithNewFields;
        }
    }
}