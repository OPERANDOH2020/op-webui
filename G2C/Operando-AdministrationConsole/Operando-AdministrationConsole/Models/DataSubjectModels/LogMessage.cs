using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using eu.operando.core.ldb.Model;
using Operando_AdministrationConsole.Helper;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class LogMessage
    {
        // Shared
        private const string RequestedAccessToPhrase = "requested access to your";

        // Parsing only
        private static readonly string ParseDescriptionRegex = "(.+) " + RequestedAccessToPhrase + " (.+)" + Regex.Escape(".") + " (.+)";
        private const string MatchRequesterBackreference = "$1";
        private const string MatchFieldsRequestedBackreference = "$2";
        private const string MatchResultBackreference = "$3";
        private const char FieldParsingSeparator = ',';

        // Display only
        private const string FieldDisplaySeparator = ", ";

        public string Message => Requester + " "+ RequestedAccessToPhrase + " " + string.Join(FieldDisplaySeparator, FieldsRequested) + ". " + Result;

        public IEnumerable<string> FieldsRequested { get; private set; }
        private string Requester { get; set; }
        private string Result { get; }

        public LogMessage(DataAccessLog entity)
        {
            Requester = Regex.Replace(entity.description, ParseDescriptionRegex, MatchRequesterBackreference);
            FieldsRequested = ParseFieldsRequseted(entity.description);
            Result = Regex.Replace(entity.description, ParseDescriptionRegex, MatchResultBackreference);
        }

        private static IEnumerable<string> ParseFieldsRequseted(string logDescription)
        {
            string fieldsInDescriptionStr = Regex.Replace(logDescription, ParseDescriptionRegex, MatchFieldsRequestedBackreference);
            IEnumerable<string> fieldsInDescriptionWithSurroundingSpaces = fieldsInDescriptionStr.Split(FieldParsingSeparator);
            IEnumerable<string> fieldsInMessage = fieldsInDescriptionWithSurroundingSpaces.Select(field => field.Trim());
            return fieldsInMessage;
        }

        public void ReplaceUserIdsWithRoles(string userIdToReplace, string roleToReplaceWith)
        {
            Requester = Requester.Replace(userIdToReplace, roleToReplaceWith);
        }

        public void HideUnwantedFields(IList<string> fieldsNotToShow)
        {
            IEnumerable<string> fieldsToShow = FieldsRequested.Where(field => !fieldsNotToShow.Contains(field));
            FieldsRequested = fieldsToShow;
        }

        public void MakeFieldnamesUserFriendly()
        {
            IEnumerable<string> fieldsWithNiceNames = FieldsRequested.Select(AmiNiceStringConverter.NiceResourceNameOrDefault);
            FieldsRequested = fieldsWithNiceNames;
        }
    }
}