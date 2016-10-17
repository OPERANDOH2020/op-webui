using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Operando_AdministrationConsole.Models;
using System.Web.Script.Serialization;
using System.Net;
using Newtonsoft.Json;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace Operando_AdministrationConsole.Controllers
{

    public class DataSubjectController : Controller
    {
        public string errMsg = String.Empty;

        public ActionResult DataAccessLogs()
        {
            List<DataAccessLog> logList = new List<DataAccessLog>();

            var jsonURL = "http://server02tecnalia.westeurope.cloudapp.azure.com:8091/operando/core/ldbsearch/log/search/";
            WebClient client = new WebClient();
            string jsonString= client.DownloadString(jsonURL);
            JArray results = JsonConvert.DeserializeObject<dynamic>(jsonString);

            // if I have results from the Json deserialization
            if(results.Count > 0)
            {
                DataAccessLog logItem = new DataAccessLog();

                foreach (JObject content in results.Children<JObject>())
                {
                    foreach (JProperty prop in content.Properties())
                    {
                        if (prop.Name == "logDate")
                        {
                            //logItem.logDate = DateTime.Now;

                            string data = prop.Value.ToString().Replace(",",".");
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
                    }

                    logList.Add(logItem);
                    
                }
            }
            else
            {
                errMsg = "Impossible to retrieve logs";
                ViewBag.Error = errMsg;
            }
            

            return View(logList);
        }



        public ActionResult AccessPreferences()
        {
            return View();
        }

        public ActionResult PrivacyWizard()
        {
            return View();
        }


    }
}