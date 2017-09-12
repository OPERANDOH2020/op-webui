namespace Operando_AdministrationConsole.Helper
{
    public class DebugNiceStringConverter : INiceStringConverter
    {
        public string NiceAccessorNameOrDefault(string accessor)
        {
            return $"*{accessor}*";
        }

        public string NiceResourceNameOrDefault(string resource)
        {
            return $"*{resource}*";
        }

        public string NiceActionNameOrDefault(string action)
        {
            return $"*{action}*";
        }

        public string NiceSubjectNameOrDefault(string subject)
        {
            return $"*{subject}*";
        }
    }
}