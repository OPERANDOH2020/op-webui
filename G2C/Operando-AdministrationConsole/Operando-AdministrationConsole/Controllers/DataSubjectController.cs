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
using System.Text;
using eu.operando.core.cpcu.cli.Model;
using eu.operando.interfaces.aapi.Model;

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

        /* Fetch OSP list and filter it with AAPI authorised OSPs */
        public List<OSPPrivacyPolicy> GetOspList()
        {
            string userBasePath = ConfigurationManager.AppSettings["userAapiBasePath"];
            var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);            

            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetServiceTicket());

            var instance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            List<OSPPrivacyPolicy> checkedOSPList = new List<OSPPrivacyPolicy>();
            try
            {
                // OSP call to get the list of service providers
                var filter = "{\"policy_text\" : \"\"}";
                var response = instance.OSPGet(filter);

                foreach (string ospItem in ospList.osps)
                {
                    foreach (OSPPrivacyPolicy ospInstance in response)
                    {
                        if ((ospInstance.PolicyUrl == ospItem) || (ospInstance.PolicyText == ospItem))
                        {
                            checkedOSPList.Add(ospInstance);
                            break;
                        }
                    }
                }
                /*
                if (checkedOSPList.Count == 0)
                {
                    checkedOSPList = response;
                }
                */
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSP list: " + e.Message);
            }
            return checkedOSPList;
        }

        /* Method modified by IT Innovation Centre 2016 */
        public ActionResult AccessPreferences()
        {
            List<OSPPrivacyPolicy> availableOSPs = GetOspList();
            if (!availableOSPs.Any())
            {
                return View(new List<ModOSPConsents>());
            }

            // get UPP for user
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetServiceTicket());

            var instance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            List<OSPConsents> userSP = new List<OSPConsents>();

            try
            {
                string username = Session["Username"].ToString();
                UserPrivacyPolicy upp = instance.UserPrivacyPolicyUserIdGet(username);
                foreach (OSPPrivacyPolicy osp in availableOSPs)
                {
                    Boolean flag = false;
                    foreach (OSPConsents consent in upp.SubscribedOspPolicies)
                    {
                        if (consent.OspId == osp.PolicyUrl)
                        {
                            userSP.Add(consent);
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        OSPConsents ospConsent = new OSPConsents();
                        ospConsent.OspId = osp.PolicyUrl;
                        ospConsent.AccessPolicies = osp.Policies;
                        userSP.Add(ospConsent);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Print("Exception with UPP calling: " + e.Message);
                foreach (OSPPrivacyPolicy osp in availableOSPs)
                {
                    OSPConsents ospConsent = new OSPConsents();
                    ospConsent.OspId = osp.PolicyUrl;
                    ospConsent.AccessPolicies = osp.Policies;
                    userSP.Add(ospConsent);
                }
            }

            //ViewBag.ospppList = userSP;
            List<ModOSPConsents> opsModList = GroupAP(userSP, userSP.ElementAt(0).OspId);
            return View(opsModList);
        }

        /* Convert list of OSPConsents to a modified view model that helps visualisation*/
        private List<ModOSPConsents> GroupAP(List<OSPConsents> consents, string selctedOspId)
        {
            List<ModOSPConsents> modConsentsList = new List<ModOSPConsents>();
            foreach(OSPConsents cons in consents)
            {
                ModOSPConsents mod = new ModOSPConsents();
                mod.OspId = cons.OspId;
                if(selctedOspId == cons.OspId)
                {
                    mod.selected = true;
                }
                mod.map = new List<GroupAccessPolicies>();
                Dictionary<string, List<AccessPolicy>> dict = new Dictionary<string, List<AccessPolicy>>();
                foreach(AccessPolicy ap in cons.AccessPolicies)
                {
                    if (dict.ContainsKey(ap.Subject))
                    {
                        dict[ap.Subject].Add(ap);
                    }
                    else
                    {
                        List<AccessPolicy> apl = new List<AccessPolicy>();
                        apl.Add(ap);
                        dict.Add(ap.Subject, apl);
                    }
                }
                foreach(KeyValuePair<string, List<AccessPolicy>> pair in dict)
                {
                    GroupAccessPolicies groupAP = new GroupAccessPolicies();
                    groupAP.groupKey = pair.Key;
                    groupAP.gap = pair.Value;
                    mod.map.Add(groupAP);
                }
                modConsentsList.Add(mod);
            }           

            return modConsentsList;
        }

        /* Method modified by IT Innovation Centre 2016 */
        [HttpPost]
        public ActionResult AccessPreferences(FormCollection resp)
        {
            
            //Debug.Print("http post here: " + Convert.ToString(resp) + Response);
            List<string> policiesKey = new List<string>();
            string resetOsp = null;
            string ospPolicyUrl = null;

            foreach (var key in resp.AllKeys)
            {
                if(key.ToString().Equals("qstage"))
                {
                    Session["QuestionnaireStage"] = 3;
                    return RedirectToAction("PrivacyQuestionnaire");
                }
                if(key.ToString().StartsWith("reset_"))
                {
                    resetOsp = key.ToString().Remove(0,6);
                    break;
                }
                //Debug.Print("resp: " + key);
                policiesKey.Add(key);
            }

            if (resetOsp == null)
            {
                policiesKey.RemoveAt(resp.Count - 1);
                ospPolicyUrl = resp.AllKeys[resp.Count - 1];
            }

            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetServiceTicket());

            var getInstance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            var putInstance = new eu.operando.core.pdb.cli.Api.PUTApi(configuration);

            var postInstance = new eu.operando.core.pdb.cli.Api.POSTApi(configuration);

            List<OSPPrivacyPolicy> checkedOSPList = GetOspList();
            List<OSPConsents> newSOP = new List<OSPConsents>();
            string selectedOSPID = "";
            try
            {  
                OSPPrivacyPolicy selectedOSP = null;                

                foreach (OSPPrivacyPolicy osp in checkedOSPList)
                {
                    Debug.Print("response: " + osp.PolicyUrl + " vs " + ospPolicyUrl);

                    if (ospPolicyUrl == osp.PolicyUrl)
                    {
                        Debug.Print("Selected OSP:" + osp.PolicyUrl);
                        selectedOSP = osp;

                        selectedOSPID = selectedOSP.PolicyUrl;
                        //selectedOSPID = selectedOSP.OspPolicyId;

                        foreach (eu.operando.core.pdb.cli.Model.AccessPolicy ap in selectedOSP.Policies)
                        {
                            string ospKey = string.Concat(string.Concat(ap.Subject.GetHashCode().ToString(), " "), ap.Resource.GetHashCode().ToString());
                            ospKey = ospKey + " " + ap.Action.GetHashCode().ToString();
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
                
                foreach (OSPConsents consent in userUPP.SubscribedOspPolicies)
                {
                    Debug.Print("checking consent: " + consent.OspId + " vs " + ospPolicyUrl + " vs " + selectedOSP.PolicyUrl);
                    if (consent.OspId == selectedOSPID)
                    {
                        found = true;
                        Debug.Print("Found matching UPP consent for UPDATE:" + consent.ToString());
                        OSPConsents updateConsent = new OSPConsents();
                        updateConsent.OspId = selectedOSPID;
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
                    newConsents.OspId = selectedOSPID;
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

            List<OSPConsents> userSP = new List<OSPConsents>();
            foreach (OSPPrivacyPolicy osp in checkedOSPList)
            {
                Boolean flag = false;
                foreach (OSPConsents consent in newSOP)
                {
                    if (consent.OspId == osp.PolicyUrl)
                    {
                        if (resetOsp != consent.OspId)
                        {
                            userSP.Add(consent);
                            flag = true;
                        }
                        break;
                    }
                }
                if (!flag)
                {
                    OSPConsents ospConsent = new OSPConsents();
                    ospConsent.OspId = osp.PolicyUrl;
                    ospConsent.AccessPolicies = osp.Policies;
                    userSP.Add(ospConsent);
                }
            }

            // return Redirect(returnUrl);
            string selected = "";
            if (resetOsp == null)
            {
                selected = selectedOSPID;
            }
            else
            {
                selected = resetOsp;
            }
            return View(GroupAP(userSP, selected));
        }

        public ActionResult PrivacyWizard()
        {
            return View();
        }

        private void checkQuestionnaireID()
        {
            if (Session["QuestionnaireId"] == null)
            {
                // check status
                string qUriBase = ConfigurationManager.AppSettings["questionnaireURL"].ToString();
                var qConfiguration = new eu.operando.core.cpcu.cli.Client.Configuration(new eu.operando.core.cpcu.cli.Client.ApiClient(qUriBase));

                var getQInstance = new eu.operando.core.cpcu.cli.Api.GETCPCUApi(qConfiguration);

                try
                {
                    var response = getQInstance.GetCPCUGET(Session["Username"].ToString(), 0, 2);
                    if (response.Response.Error.Equals(""))
                    {
                        Session["QuestionnaireId"] = 2;
                        Session["QuestionnaireStage"] = 3;
                    }
                    else
                    {
                        Session["QuestionnaireId"] = 0;
                        if (Session["QuestionnaireStage"] == null)
                        {
                            // initial case, i.e. user clicked on privacy QN first time
                            Session["QuestionnaireStage"] = 1;
                        }
               
                    }
                }
                catch (Exception e)
                {
                    // failed to connect to CPCU server
                }
            }
            Debug.Print("QuestionnaireId is: " + Session["QuestionnaireId"]);
        }

        [HttpGet]
        //public async Task<ActionResult> PrivacyQuestionnaire()
        public ActionResult PrivacyQuestionnaire()
        {             
            checkQuestionnaireID();
           
            if((int)Session["QuestionnaireId"] > 3)
            {
                // no need to run questionnaire
                return RedirectToAction("Index", "Dashboard");
            }
            /*
            if(Session["QuestionnaireId"] == null)
            {
                Session["QuestionnaireId"] = 0;
                Session["QuestionnaireStage"] = 1;
            }*/
            string qUriBase = ConfigurationManager.AppSettings["questionnaireURL"].ToString();
            var qConfiguration = new eu.operando.core.cpcu.cli.Client.Configuration(new eu.operando.core.cpcu.cli.Client.ApiClient(qUriBase));

            var getQInstance = new eu.operando.core.cpcu.cli.Api.GETCPCUApi(qConfiguration);

            try
            {
                var response = getQInstance.GetCPCUGET(Session["Username"].ToString(), 0, (int)Session["QuestionnaireId"]);
                if (response.Response.Error.Equals(""))
                {
                    int counter = 101;
                    foreach (var cat in response.Response.Questionnaire.Category)
                    {
                        foreach (var statement in cat.Statements)
                        {
                            statement.Rating = counter++;
                        }
                    }
                    Session["questionnaire"] = response;
                    ViewBag.questionnaire = response.Response.Questionnaire;
                }
            } catch (Exception e)
            {

            }
            return View();
        }

        [HttpPost]
        //public async Task<ActionResult> PrivacyQuestionnaire(FormCollection formCol)
        public ActionResult PrivacyQuestionnaire(FormCollection formCol)
        {
            string qUriBase = ConfigurationManager.AppSettings["questionnaireURL"].ToString();
            int qId = int.Parse(Session["QuestionnaireId"].ToString());
            QNRootObject qGet = Session["questionnaire"] as QNRootObject;
            // update questionnaire ratings
            foreach (var cat in qGet.Response.Questionnaire.Category)
            {
                foreach (var statement in cat.Statements)
                {
                    statement.Rating = int.Parse(Request.Form["radio" + statement.Rating].ToString());
                }
            }

            Session["questionnaire"] = null;

            var qConfiguration = new eu.operando.core.cpcu.cli.Client.Configuration(new eu.operando.core.cpcu.cli.Client.ApiClient(qUriBase));
            var postQInstance = new eu.operando.core.cpcu.cli.Api.POSTCPCUApi(qConfiguration);
            var getPrefsInstance = new eu.operando.core.cpcu.cli.Api.GETPreferencesApi(qConfiguration);

            try
            {
                var response = postQInstance.PostCPCUPOST(Session["Username"].ToString(), 0, (int)Session["QuestionnaireId"], qGet);
                if (response.Response.Error.Equals("Successfully submitted"))
                {
                    Session["QuestionnaireId"] = qId + 1;
                    // if (qId == 0)
                    if (qId < (int)Session["QuestionnaireStage"])
                    {
                        return RedirectToAction("PrivacyQuestionnaire", "DataSubject");
                    }
                    else
                    {
                        Session.Remove("QuestionnaireId");
                        // updateUPP, fetch preferences first
                        PrefRootObject resPref = getPrefsInstance.GetPreferencesGET(Session["Username"].ToString(), 0);
                        
                            if (resPref.Response.Error.Equals(""))
                            {
                                List<UserPreference> userPrefList = new List<UserPreference>();

                                foreach (Preference pref in resPref.Response.Preferences)
                                {
                                    UserPreference uPref = new UserPreference();
                                    uPref.Category = pref.Category;
                                    uPref.Preference = pref._Preference;
                                    if (pref.Role != null)
                                    {
                                        uPref.Role = pref.Role;
                                    }
                                    if (pref.Action != null)
                                    {
                                        uPref.Action = pref.Action;
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
    
            return View();
        }

    }
}
