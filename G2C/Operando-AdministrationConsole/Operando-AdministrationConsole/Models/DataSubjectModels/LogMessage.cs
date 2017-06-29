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
        private static readonly string PhraseWithFieldsRegex = "(.+requested access to your )(.*)(" + Regex.Escape(".") + ".+)";
        private const string GetFieldsRegex = "$2";
        private const string ReplaceFieldsRegexPrefix = "$1";
        private const string ReplaceFieldsRegexSuffix = "$3";

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

        public void ReplaceUserIdsWithRoles(string userIdToReplace, string roleToReplaceWith)
        {
            Message = Message.Replace(userIdToReplace, roleToReplaceWith);
        }

        public void HideUnwantedFields(IList<string> fieldsNotToShow)
        {
            IEnumerable<string> fieldsToShow = FieldsInMessage.Where(field => !fieldsNotToShow.Contains(field));
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