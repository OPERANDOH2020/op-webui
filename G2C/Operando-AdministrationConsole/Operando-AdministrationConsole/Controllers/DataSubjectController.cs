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
using System.Diagnostics;
using eu.operando.core.pdb.cli.Model;

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

        /* Method modified by IT Innovation Centre 2016 */
        public ActionResult AccessPreferences()
        {
            //string pdbBasePath = "http://172.16.0.59:8080/pdb-server/policy_database";
            string pdbBasePath = "http://integration.operando.esilab.org:8096/operando/core/pdb";

            var instance = new eu.operando.core.pdb.cli.Api.GETApi(pdbBasePath);

            Debug.Print("SESSION USER: " + Session["Username"]);

            try
            {
                var filter = "filter=\"%7B%27policyText%27:%27%27%7D\"";
                var response = instance.OSPGet(filter);
                ViewBag.ospppList = response;
                return View(response);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PrivacyLegislationApi.RegulationsPost: " + e.Message);
            }
            return View();
        }

        /* Method modified by IT Innovation Centre 2016 */
        [HttpPost]
        public ActionResult AccessPreferences(FormCollection resp)
        {
            //Debug.Print("http post here: " + Convert.ToString(resp) + Response);
            List<string> policiesKey = new List<string>();

            foreach (var key in resp.AllKeys)
            {
                //Debug.Print("resp: " + key);
                policiesKey.Add(key);
            }

            policiesKey.RemoveAt(resp.Count - 1);

            //string pdbBasePath = "http://172.16.0.59:8080/pdb-server/policy_database";
            string pdbBasePath = "http://integration.operando.esilab.org:8096/operando/core/pdb";

            var getInstance = new eu.operando.core.pdb.cli.Api.GETApi(pdbBasePath);

            var putInstance = new eu.operando.core.pdb.cli.Api.PUTApi(pdbBasePath);

            var postInstance = new eu.operando.core.pdb.cli.Api.POSTApi(pdbBasePath);

            try
            {
                var filterOSP = "filter=\"%7B%27policyText%27:%27%27%7D\"";
                var response = getInstance.OSPGet(filterOSP);
                ViewBag.ospppList = response;

                // extract OSP list urls
                OSPPrivacyPolicy selectedOSP = null;
                string ospPolicyUrl = resp.AllKeys[resp.Count - 1];

                foreach (OSPPrivacyPolicy osp in response)
                {
                    Debug.Print("response: " + osp.PolicyUrl + " vs " + ospPolicyUrl);

                    if (ospPolicyUrl == osp.PolicyUrl)
                    {
                        Debug.Print("Selected OSP:" + osp.PolicyUrl);
                        selectedOSP = osp;

                        foreach (eu.operando.core.pdb.cli.Model.AccessPolicy ap in selectedOSP.Policies)
                        {
                            string ospKey = string.Concat(string.Concat(ap.Subject.GetHashCode().ToString(), " "), ap.Resource.GetHashCode().ToString());
                            bool foundL = false;

                            foreach (string item in policiesKey)
                            {
                                if (item.Contains(ospKey))
                                {
                                    ap.Permission = true;
                                    foundL = true;
                                    break;
                                }
                            }

                            if (!foundL)
                            {
                                ap.Permission = false;
                            }
                        }
                        break;
                    }
                }


                Debug.Print("Selected OSP updated: " + selectedOSP.ToJson());

                //var username = "pjgrace";
                var username = Session["Username"].ToString();
                UserPrivacyPolicy userUPP;
                try
                {
                    userUPP = getInstance.UserPrivacyPolicyUserIdGet(username);
                }
                catch (Exception e)
                {
                    Debug.Print("Exception when calling pdb-server get upp: " + e.Message);
                    // create an empty UPP
                    userUPP = new UserPrivacyPolicy();
                    userUPP.UserId = username;
                    userUPP.SubscribedOspPolicies = new List<OSPConsents>();
                    userUPP.SubscribedOspSettings = new List<OSPSettings>();
                    userUPP.UserPreferences = new List<UserPreference>();
                    postInstance.UserPrivacyPolicyPost(userUPP);
                }
                //Debug.Print("UPP old:" + userUPP.ToJson());

                bool found = false;
                List<OSPConsents> newSOP = new List<OSPConsents>();
                foreach (OSPConsents consent in userUPP.SubscribedOspPolicies)
                {
                    Debug.Print("checking consent: " + consent.OspId + " vs " + ospPolicyUrl + " vs " + selectedOSP.PolicyUrl);
                    if (consent.OspId == ospPolicyUrl)
                    {
                        found = true;
                        Debug.Print("Found matching UPP consent for UPDATE:" + consent.ToString());
                        OSPConsents updateConsent = new OSPConsents();
                        updateConsent.OspId = selectedOSP.PolicyUrl;
                        updateConsent.AccessPolicies = selectedOSP.Policies;
                        newSOP.Add(updateConsent);
                    }
                    else
                    {
                        Debug.Print("Copy old policy only");
                        newSOP.Add(consent);
                    }
                }

                // Adding a new policy
                if (!found)
                {
                    Debug.Print("Add new consent to OSP policy: " + selectedOSP.PolicyUrl);
                    OSPConsents newConsents = new OSPConsents();
                    newConsents.OspId = selectedOSP.PolicyUrl;
                    newConsents.AccessPolicies = selectedOSP.Policies;
                    newSOP.Add(newConsents);
                }

                userUPP.SubscribedOspPolicies = newSOP;
                Debug.Print("update new subscribed OSP policies:" + userUPP.ToJson());

                putInstance.UserPrivacyPolicyUserIdPut(username, userUPP);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling pdb-server: " + e.Message);
            }
            return View();
        }

        public ActionResult PrivacyWizard()
        {
            return View();
        }


    }
}
