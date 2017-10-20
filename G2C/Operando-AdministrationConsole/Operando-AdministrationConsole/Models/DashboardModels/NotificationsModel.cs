using System;
using System.Web.Mvc;
using eu.operando.core.ldb.Model;

namespace Operando_AdministrationConsole.Models.DashboardModels
{
    public class NotificationsModel
    {
        private const string PrivacySettingsUpdatedStr = "privacy settings";
        private const string OspPolicyChangeStr = "osp privacy Policy";

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// The string representing the URL to go to under the action column.
        /// </summary>
        public string ActionUrl { get; set; }

        public NotificationsModel(DataAccessLog log, UrlHelper urlHelper)
        {
            Title = log.title;
            Description = log.description;
            TimeStamp = log.logDate;
            ActionUrl = GetActionUrl(log.title, urlHelper);
        }

        private static string GetActionUrl(string title, UrlHelper urlHelper)
        {
            if (title.StartsWith(PrivacySettingsUpdatedStr, StringComparison.InvariantCultureIgnoreCase))
            {
                return urlHelper.Action("AccessPreferences", "DataSubject");
            }

            if (title.StartsWith(OspPolicyChangeStr, StringComparison.InvariantCultureIgnoreCase))
            {
                return urlHelper.Action("PrivacyPolicy", "OspAdmin");
            }

            return string.Empty;
        }
    }
}