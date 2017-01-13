using Operando_AdministrationConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Extension
{
    public static class ExtensionMethods
    {
        public static string UserFriendlyName(this PrivateInformationTypeEnum e)
        {
            string userFriendlyName = "";
            switch (e)
            {
                case PrivateInformationTypeEnum.SharedIdentification:
                    userFriendlyName = "Shared Identification";
                    break;
                case PrivateInformationTypeEnum.NetworkAndRelationships:
                    userFriendlyName = "Network and Relationships";
                    break;
                default:
                    userFriendlyName = Enum.GetName(typeof(PrivateInformationTypeEnum), e);
                    break;
            }
            return userFriendlyName;
        }

        public static string TruncateWithEllipsis(this string s, int maxLength)
        {
            string truncatedString = "";

            if (s.Length > maxLength)
            {
                truncatedString = s.Substring(0, maxLength) + "...";
            }
            else
            {
                truncatedString = s;
            }

            return truncatedString;
        }
    }
}