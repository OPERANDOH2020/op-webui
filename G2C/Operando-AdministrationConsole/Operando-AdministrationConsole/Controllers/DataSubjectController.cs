using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Operando_AdministrationConsole.Models;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;
using eu.operando.core.pdb.cli.Model;
using System.Configuration;
using System.Linq;
using eu.operando.interfaces.aapi;
using System.Threading.Tasks;
using System.Net.Http;
using eu.operando.core.ldb;
using Operando_AdministrationConsole.Models.DataSubjectModels;

namespace Operando_AdministrationConsole.Controllers
{

    public class DataSubjectController : Controller
    {
        private readonly IAapiClient _aapiClient;
        private readonly ILdbClient _ldbClient;

        public string errMsg = String.Empty;
        //private QRootObject qGet;

        public DataSubjectController()
        {
            _aapiClient = new AapiClient();
            _ldbClient = new LdbClient();
        }

        public ActionResult DataAccessLogs()
        {
            List<DataAccessLogModel> logList = new List<DataAccessLogModel>();

            try
            {
                var username = Session["Username"] as string;

                var entities = _ldbClient.GetDataAccessLogs(username);

                logList = entities.Select(_ => new DataAccessLogModel(_)).ToList();
            }
            catch (Exception)
            {
                errMsg = "Impossible to retrieve logs";
                ViewBag.Error = errMsg;
            }


            return View(logList);
        }

        /* Method modified by IT Innovation Centre 2017 */
        private string GetServiceTicket()
        {
            string pdbOSPSId = ConfigurationManager.AppSettings["pdbOSPSId"];

            string ticketGrantingTicket = Session["TGT"] as string;

            return _aapiClient.GetServiceTicket(ticketGrantingTicket, pdbOSPSId);
            }

        /* Method modified by IT Innovation Centre 2016 */
        public ActionResult AccessPreferences()
        {
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetServiceTicket());
            
            var instance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            try
            {
                // OSP call to get the list of service providers
                var filter = "{\"policy_text\" : \"\"}";
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
            
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetServiceTicket());            
            
            var getInstance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            var putInstance = new eu.operando.core.pdb.cli.Api.PUTApi(configuration);

            var postInstance = new eu.operando.core.pdb.cli.Api.POSTApi(configuration);

            try
            {
                var filterOSP = "{\"policy_text\" : \"\"}";
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
                        updateConsent.OspId = selectedOSP.OspPolicyId;
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
                    newConsents.OspId = selectedOSP.OspPolicyId;
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

        [HttpGet]
        public async Task<ActionResult> PrivacyQuestionnaire()
        {
            if (Session["QuestionnaireId"] == null)
            {
                Session["QuestionnaireId"] = 0;
            }
            string qUriBase = ConfigurationManager.AppSettings["questionnaireURL"].ToString();

            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetAsync(new Uri(qUriBase + Session["Username"] +
                    "/0/" + Session["QuestionnaireId"].ToString()));
                Response.StatusCode = (int)result.StatusCode;
                var content = await result.Content.ReadAsStringAsync();
                
                    L3QRootObject qGet = JsonConvert.DeserializeObject<L3QRootObject>(content);
                    if (qGet.response.error.Equals(""))
                    {
                        int counter = 101;
                        foreach (var cat in qGet.response.questionnaire.category)
                        {
                            foreach (var statement in cat.statements)
                            {
                                statement.rating = counter++;
                            }
                        }
                        Session["questionnaire"] = qGet;
                        ViewBag.questionnaire = qGet.response.questionnaire;
                    }
                }
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> PrivacyQuestionnaire(FormCollection formCol)
        {
            string qUriBase = ConfigurationManager.AppSettings["questionnaireURL"].ToString();
            int qId = int.Parse(Session["QuestionnaireId"].ToString());
                L3QRootObject qGet = Session["questionnaire"] as L3QRootObject;
                // update questionnaire ratings
                foreach (var cat in qGet.response.questionnaire.category)
                {
                    foreach (var statement in cat.statements)
                    {
                        statement.rating = int.Parse(Request.Form["radio" + statement.rating].ToString());
                    }
                }


            Session["questionnaire"] = null;

            // post questionnaire to server
            using (HttpClient client = new HttpClient())
            {
               try
                    {
                    var httpResponseMessage = await client.PostAsJsonAsync(new Uri(qUriBase + Session["Username"] +
                        "/0/" + Session["QuestionnaireId"].ToString()), qGet);
                    if (httpResponseMessage.StatusCode == HttpStatusCode.Accepted)
                    {
                        
                        Session["QuestionnaireId"] = qId + 1;
                        // if (qId == 0)
                        if (qId < 3)
                        {
                            return RedirectToAction("PrivacyQuestionnaire", "DataSubject");
                        }
                        else
                        {
                            Session.Remove("QuestionnaireId");
                            // updateUPP, fetch preferences first
                            var result = await client.GetAsync(new Uri(qUriBase + Session["Username"] + "/0/"));
                            Response.StatusCode = (int)result.StatusCode;
                            var content = await result.Content.ReadAsStringAsync();
                            QPRootObject qRGet = JsonConvert.DeserializeObject<QPRootObject>(content);
                            if (qRGet.response.error.Equals(""))
                            {
                                List<UserPreference> userPrefList = new List<UserPreference>();

                                foreach(QPPreference pref in qRGet.response.preferences)
                                {
                                    UserPreference uPref = new UserPreference();
                                    uPref.Category = pref.category;
                                    uPref.Preference = pref.preference;
                                    if (pref.role != null)
                                    {
                                        uPref.Role = pref.role;
                                    }
                                    if (pref.action != null)
                                    {
                                        uPref.Action = pref.action;
                                    }
                                    userPrefList.Add(uPref);
                                }

                                string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
                                string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

                                var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
                                configuration.AddDefaultHeader(stHeaderName, GetServiceTicket());

                                var getInstance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);
                                

                                var username = Session["Username"].ToString();
                                UserPrivacyPolicy userUPP;
                                try
                                {
                                    userUPP = getInstance.UserPrivacyPolicyUserIdGet(username);                                    
                                    userUPP.UserPreferences = userPrefList;

                                    // update upp
                                    var putInstance = new eu.operando.core.pdb.cli.Api.PUTApi(configuration);
                                    putInstance.UserPrivacyPolicyUserIdPut(username, userUPP);
                                }
                                catch (Exception e)
                                {
                                    Debug.Print("Exception when calling pdb-server get upp: " + e.Message);
                                    // create an empty UPP
                                    userUPP = new UserPrivacyPolicy();
                                    userUPP.UserId = username;
                                    userUPP.SubscribedOspPolicies = new List<OSPConsents>();
                                    userUPP.SubscribedOspSettings = new List<OSPSettings>();
                                    userUPP.UserPreferences = userPrefList;

                                    // upp
                                    var postInstance = new eu.operando.core.pdb.cli.Api.POSTApi(configuration);
                                    postInstance.UserPrivacyPolicyPost(userUPP);
                                }
                                
                            }

                        return RedirectToAction("Index", "Dashboard");
                        }
                    }
                } 
                catch (OperationCanceledException) { }
            }
            return View();
        }

    }
}
