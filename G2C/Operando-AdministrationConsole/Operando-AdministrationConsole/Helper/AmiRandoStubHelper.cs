using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operando_AdministrationConsole.Models;
using System.Web.Mvc.Html;

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

        public static List<Notification> GetStubNotifications()
        {
            List<Notification> stubNotifications = new List<Notification>();

            string messageSuggestedChangeToUpp = "Ami's Privacy Policy has been updated. If you give it permission to do so,"
                + " Ami will now use your age to generate a report on the needs of registered clients within West London,"
                + " broken down by geographical area and age. The report will not contain any personally identifiable information."
                + "\n"
                + "\n"
                + " If you would like your information to be available for this report,"
                + " you should make sure that your user privacy policy (UPP) allows the Anonymised Report Generator access to your age.";

            stubNotifications.Add(new Notification(new DateTime(2017, 1, 17, 9, 12, 35), messageSuggestedChangeToUpp, "/DataSubject/AccessPreferences", "Edit UPP"));

            string messageNoChangeToUpp = "Ami's Privacy Policy has been updated. There are no recommended changes to your privacy policy.";
            stubNotifications.Add(new Notification(new DateTime(2016, 12, 9, 16, 11, 24), messageNoChangeToUpp));
            stubNotifications.Add(new Notification(new DateTime(2016, 9, 11, 15, 04, 01), messageNoChangeToUpp));
            stubNotifications.Add(new Notification(new DateTime(2016, 6, 3, 16, 19, 47), messageNoChangeToUpp));

            return stubNotifications;
        }


        public class Notification
        {
            public DateTime DateTime { get; set; }
            public string Message { get; set; }
            public string Link { get; set; }
            public string LinkText { get; set; }

            public Notification(DateTime dateTime, string message)
            {
                this.DateTime = dateTime;
                this.Message = message;
            }

            public Notification(DateTime dateTime, string message, string link, string linkText) : this(dateTime, message)
            {
                this.Link = link;
                this.LinkText = linkText;
            }
        }
    }
}
