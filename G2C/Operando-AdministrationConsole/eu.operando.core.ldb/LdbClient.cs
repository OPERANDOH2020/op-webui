﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using eu.operando.core.ldb.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eu.operando.core.ldb
{
    public class LdbClient : ILdbClient
    {
        private readonly string _baseUrl;

        public LdbClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public IList<DataAccessLog> GetDataAccessLogs(string userId)
        {
            return RequestDataAccessLogs($"logType=data_access&affectedUserId={userId}");
        }

        public IList<DataAccessLog> GetNotifications(string userId)
        {
            return RequestDataAccessLogs($"logType=notification&affectedUserId={userId}");
        }

        public IList<DataAccessLog> GetDataAccessOspLogs(string ospId)
        {
            return RequestDataAccessLogs($"logType=data_access&ospId={ospId}");
        }
        private List<DataAccessLog> RequestDataAccessLogs(string searchString)
        {
            List<DataAccessLog> logList = new List<DataAccessLog>();
            
            string jsonString;
            using (WebClient client = new WebClient())
            {
                jsonString = client.DownloadString(_baseUrl + "?" + searchString);
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
                        if (prop.Name == nameof(logItem.ospId))
                            logItem.ospId = prop.Value.ToString();
                        if (prop.Name == nameof(logItem.arrayRequestedFields))
                            logItem.arrayRequestedFields = prop.Value.Children().Select(a => a.ToString()).ToArray();
                        if (prop.Name == nameof(logItem.arrayGrantedFields))
                            logItem.arrayGrantedFields = prop.Value.Children().Select(a => a.ToString()).ToArray();
                    }

                    logList.Add(logItem);
                }
            }


            return logList;
        }
    }
}
