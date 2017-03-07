
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Operando_AdministrationConsole.Models;

namespace Operando_AdministrationConsole.Helper
{
    /// <summary>
    /// TODO: replace with a separate project eu.operando.core.ldb
    /// This is a temporary implementation
    /// </summary>
    public class LdbService
    {

        public List<DataAccessLog> GetDataAccessLogs(string userId)
        {
            return RequestDataAccessLogs($"logType=data_access&affectedUserId={userId}");
        }

        public List<DataAccessLog> GetNotifications(string userId)
        {
            return RequestDataAccessLogs($"logType=notification&affectedUserId={userId}&viewed=false");
        }

        private List<DataAccessLog> RequestDataAccessLogs(string searchString)
        {
            List<DataAccessLog> logList = new List<DataAccessLog>();

            var baseURL = "http://integration.operando.esilab.org:8091/operando/core/ldbsearch/log/search";

            string jsonString;
            using (WebClient client = new WebClient())
            {
                jsonString = client.DownloadString(baseURL + "?" + searchString);
            }


            JArray results = JsonConvert.DeserializeObject<dynamic>(jsonString);

            // if I have results from the Json deserialization
            if (results.Count > 0)
            {
                foreach (JObject content in results.Children<JObject>())
                {
                    DataAccessLog logItem = new DataAccessLog();

                    foreach (JProperty prop in content.Properties())
                    {
                        if (prop.Name == "logDate")
                        {
                            string data = prop.Value.ToString().Replace(",", ".");
                            logItem.logDate = Convert.ToDateTime(data);
                        }

                        if (prop.Name == "requesterType")
                            logItem.requesterType = prop.Value.ToString();
                        if (prop.Name == "requesterId")
                            logItem.requesterId = prop.Value.ToString();
                        if (prop.Name == "logPriority")
                            logItem.logPriority = prop.Value.ToString();
                        if (prop.Name == "logLevel")
                            logItem.logLevel = prop.Value.ToString();
                        if (prop.Name == "title")
                            logItem.title = prop.Value.ToString();
                        if (prop.Name == "description")
                            logItem.description = prop.Value.ToString();
                        if (prop.Name == "logType")
                            logItem.logType = prop.Value.ToString();
                        if (prop.Name == "affectedUserId")
                            logItem.affectedUserId = prop.Value.ToString();
                        if (prop.Name == "viewed")
                            logItem.viewed = bool.Parse(prop.Value.ToString());
                    }

                    logList.Add(logItem);
                }
            }
            else
            {
                throw new Exception("No json results found");
            }


            return logList;
        }
    }
}