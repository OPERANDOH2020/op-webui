using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operando_AdministrationConsole.Models;

namespace Operando_AdministrationConsole.Helper
{
    public class AmiRandoStubHelper
    {
        private const string DataTypeCareNeeds = "Care Needs";
        private const string DataTypeAddressInformation = "Address Information";

        public static List<DataAccessLog> GetStubAccessLogs()
        {
            List<DataAccessLog> logList = new List<DataAccessLog>();

            DataAccessLog stubLogItem = CreateStubLogItem(false, DataTypeCareNeeds);
            logList.Add(stubLogItem);

            DataAccessLog stubLogItem3 = CreateStubLogItem(true, DataTypeCareNeeds);
            logList.Add(stubLogItem3);

            DataAccessLog stubLogItem2 = CreateStubLogItem(false, DataTypeAddressInformation);
            logList.Add(stubLogItem2);

            DataAccessLog stubLogItem4 = CreateStubLogItem(true, DataTypeAddressInformation);
            logList.Add(stubLogItem4);

            logList.Sort((log1,log2) => log2.logDate.CompareTo(log1.logDate));

            return logList;
        }

        private static DataAccessLog CreateStubLogItem(Boolean accessGranted, string dataType)
        {
            DataAccessLog logItem = new DataAccessLog();
            logItem.requesterType = "Ami";
            logItem.requesterId = "Anonymised Report Generator";
            logItem.logPriority = "NORMAL";
            logItem.description =
                "Your " + dataType + " data was requested.";

            if (accessGranted)
            {
                logItem.logDate = DateTime.Now.AddMinutes(-1);
                logItem.logLevel = "INFO";
                logItem.title = "Data Request Granted";
                logItem.description +=
                    " Your data was returned: the request complied with your user privacy policy (UPP).";
            }
            else
            {
                logItem.logDate = DateTime.Now.AddMinutes(-3);
                logItem.logLevel = "WARN";
                logItem.title = "Data Request Denied";
                logItem.description +=
                    " Your data was not returned: the request did not comply with your user privacy policy (UPP).";
            }

            logItem.description += " Click the \"Edit UPP Settings\" button if you would like to change your UPP.";

            return logItem;
        }
    }
}
