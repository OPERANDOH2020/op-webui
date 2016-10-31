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
    }
}