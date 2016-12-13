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

            // TODO: SUBSTITUTE WITH REAL LOGGED USER ID -- WAITING FOR FEEDBACK FROM PAUL
            //string loggedUserId = "1"; 

            // TODO: STILL PROBLEMS WITH FILTERING -- WAITING FOR FEEDBACK FROM COSTAS
            //var jsonURL = String.Format("http://server02tecnalia.westeurope.cloudapp.azure.com:8091/operando/core/ldbsearch/log/search/?dateFrom&dateTo&logLevel&requesterType={0}&requesterId={1}&logPriority&title&keyWords", "USER", loggedUserId );
            var jsonURL = "http://integration.operando.esilab.org:8091/operando/core/ldbsearch/log/search";

            WebClient client = new WebClient();
            string jsonString = client.DownloadString(jsonURL);


            // da cancellare
            /*string jsonString;
            try
            {
                jsonString = client.DownloadString(jsonURL);
            }
            catch(Exception e)
            {
                DataAccessLog logItem = new DataAccessLog();
                string data = "22/11/2016";

                logItem.logDate = Convert.ToDateTime(data);
                logItem.requesterType = "requesterType";
                logItem.requesterId = "requesterId";
                logItem.logPriority = "logPriority";
                logItem.logLevel = "INFO";
                logItem.title = "title";
                logItem.description = "description";

                logList.Add(logItem);

                return View(logList);
            }*/
            // fine cancellare


            JArray results = JsonConvert.DeserializeObject<dynamic>(jsonString);

            // if I have results from the Json deserialization
            if(results.Count > 0)
            {
                foreach (JObject content in results.Children<JObject>())
                {
                    DataAccessLog logItem = new DataAccessLog();

                    foreach (JProperty prop in content.Properties())
                    {
                        if (prop.Name == "logDate")
                        {
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