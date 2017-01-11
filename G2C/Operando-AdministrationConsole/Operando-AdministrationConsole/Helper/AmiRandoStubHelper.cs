using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operando_AdministrationConsole.Models;
using System.Web.Mvc.Html;
using eu.operando.core.pdb.cli.Model;
using AccessPolicy = eu.operando.core.pdb.cli.Model.AccessPolicy;

namespace Operando_AdministrationConsole.Helper
{
    public class AmiRandoStubHelper
    {
        private const string UserTypeAmiReportGenerator = "Anonymised Report Generator";
        private const string UserTypeVolunteerOrganisationEmployee = "Volunteer Organisation Employees";
        private const string UserTypeAmiStaff = "Ami Staff";
        private static List<string> UserTypes = new List<string>() { UserTypeAmiReportGenerator, UserTypeVolunteerOrganisationEmployee, UserTypeAmiStaff };

        private const string DataTypeCareNeeds = "Care Needs";
        private const string DataTypeAddressInformation = "Address Information";
        private const string DataTypeAge = "Age";
        private static List<string> DataTypes = new List<string>() { DataTypeCareNeeds, DataTypeAddressInformation, DataTypeAge};
        private static List<OSPPrivacyPolicy> _userPrivacyPolicy = InitialiseAmiUserPrivacyPolicy();

        private const string MessageSuggestedChangeToUpp = "Ami's Privacy Policy has been updated. If you give it permission to do so,"
                                                           + " Ami will now use your age to generate a report on the needs of registered clients within West London,"
                                                           + " broken down by geographical area and age. The report will not contain any personally identifiable information."
                                                           + "\n"
                                                           + "\n"
                                                           + "If you would like your information to be available for this report,"
                                                           + " you should make sure that your user privacy policy (UPP) allows the Anonymised Report Generator access to your"
                                                           + " care needs, address information, and age.";
        
        private const string MessageNoChangeToUpp = "Ami's Privacy Policy has been updated. There are no recommended changes to your privacy policy.";
        private const string MessageRegulation = "The choice of options for your UPP were updated to reflect an update to a data protection regulation.";
        private const string MessageDataRequested = "Your data has been requested 5 times so far today.";

        public static List<DataAccessLog> GetStubAccessLogs()
        {
            List<DataAccessLog> logList = new List<DataAccessLog>();

            DataAccessLog stubLogItemCareNeedsDenied = CreateStubLogItem(false, DataTypeCareNeeds);
            DataAccessLog stubLogItemAddressDenied = CreateStubLogItem(false, DataTypeAddressInformation);
            DataAccessLog stubLogItemCareNeedsAllowed = CreateStubLogItem(true, DataTypeCareNeeds);
            DataAccessLog stubLogItemAddressAllowed = CreateStubLogItem(true, DataTypeAddressInformation);

            logList.Add(stubLogItemCareNeedsDenied);
            logList.Add(stubLogItemAddressDenied);

            OSPPrivacyPolicy amiPrivacyPolicy = _userPrivacyPolicy[0];
            List<AccessPolicy> amiAccessPolicies = amiPrivacyPolicy.Policies;

            if (amiAccessPolicies.Contains(new AccessPolicy(UserTypeAmiReportGenerator, true, null, DataTypeCareNeeds,
                    new List<PolicyAttribute>()))
                &&
                amiAccessPolicies.Contains(new AccessPolicy(UserTypeAmiReportGenerator, true, null, DataTypeCareNeeds,
                    new List<PolicyAttribute>())))
            {
                logList.Add(stubLogItemCareNeedsAllowed);
                logList.Add(stubLogItemAddressAllowed);
            }

            Comparison<DataAccessLog> mostRecentFirst = (log1,log2) => log2.logDate.CompareTo(log1.logDate);
            logList.Sort(mostRecentFirst);

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

            stubNotifications.Add(new Notification(DateTime.Now, MessageDataRequested));
            stubNotifications.Add(new Notification(new DateTime(2017, 1, 17, 10, 12, 35), MessageSuggestedChangeToUpp, "/DataSubject/AccessPreferences", "Edit UPP"));
            stubNotifications.Add(new Notification(new DateTime(2017, 1, 17, 9, 26, 14), MessageRegulation));
            stubNotifications.Add(new Notification(new DateTime(2016, 12, 9, 16, 11, 24), MessageNoChangeToUpp));

            Comparison<Notification> mostRecentFirst = (notification1, notification2) => notification2.DateTime.CompareTo(notification1.DateTime);
            stubNotifications.Sort(mostRecentFirst);

            return stubNotifications;
        }

        public static List<OSPPrivacyPolicy> GetAmiUserPrivacyPolicy()
        {
            return _userPrivacyPolicy;
        }
        internal static void UpdateAmiUserPrivacyPolicy(Dictionary<string, List<string>> dictionaryHashCodesUserTypeToDataTypes)
        {
            List<OSPPrivacyPolicy> ospPrivacyPolicies = new List<OSPPrivacyPolicy>();
            List<AccessPolicy> amiAccessPolicies = new List<AccessPolicy>();

            foreach (string userType in UserTypes)
            {
                foreach (string dataType in DataTypes)
                {
                    string userTypeHashCode = userType.GetHashCode().ToString();
                    string dataTypeHashCode = dataType.GetHashCode().ToString();

                    bool accessAllowed =
                        dictionaryHashCodesUserTypeToDataTypes.ContainsKey(userTypeHashCode)
                        && dictionaryHashCodesUserTypeToDataTypes[userTypeHashCode].Contains(dataTypeHashCode);

                    amiAccessPolicies.Add(new AccessPolicy(userType, accessAllowed, null, dataType, new List<PolicyAttribute>()));
                }
            }

            OSPPrivacyPolicy amiPrivacyPolicy = new OSPPrivacyPolicy("Ami", "policyText", "Ami", null, amiAccessPolicies);
            ospPrivacyPolicies.Add(amiPrivacyPolicy);

            _userPrivacyPolicy = ospPrivacyPolicies;
        }

        private static List<OSPPrivacyPolicy> InitialiseAmiUserPrivacyPolicy()
        {
            List<OSPPrivacyPolicy> ospPrivacyPolicies = new List<OSPPrivacyPolicy>();
            List<AccessPolicy> amiAccessPolicies = new List<AccessPolicy>();

            foreach (string userType in UserTypes)
            {
                foreach (string dataType in DataTypes)
                {
                    amiAccessPolicies.Add(new AccessPolicy(userType, false, null, dataType, new List<PolicyAttribute>()));
                }
            }

            OSPPrivacyPolicy amiPrivacyPolicy = new OSPPrivacyPolicy("Ami", "policyText", "Ami", null, amiAccessPolicies);
            ospPrivacyPolicies.Add(amiPrivacyPolicy);
            return ospPrivacyPolicies;
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
