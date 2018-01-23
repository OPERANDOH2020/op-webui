using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Operando_AdministrationConsole.Models;
using System.Diagnostics;
using eu.operando.core.pdb.cli.Model;
using System.Configuration;
using System.Linq;
using eu.operando.interfaces.aapi;
using eu.operando.core.ldb;
using Operando_AdministrationConsole.Models.DataSubjectModels;
using eu.operando.interfaces.aapi.Model;
using eu.operando.core.pc.pq.Model;
using Operando_AdministrationConsole.Helper;

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
            _ldbClient = new LdbClient(ConfigurationManager.AppSettings["ldbBasePath"]);
        }

        public ActionResult DataAccessLogs()
        {
            List<DataAccessLogModel> logList = new List<DataAccessLogModel>();

            try
            {
                var username = Session["Username"] as string;

                var entities = _ldbClient.GetDataAccessLogs(username);


                var osps = GetAuthorisedOspList();

                var groupedByOsp = entities
                    .Where(l => l.arrayRequestedFields.Any())
                    .GroupBy(e => e.ospId);

                var logs = groupedByOsp
                    .SelectMany(es =>
                    {
                        var resourceCache = new ResourceFriendlyNameCache(osps.Where(o => string.Equals(o.PolicyUrl, es.Key, StringComparison.CurrentCultureIgnoreCase))
                            .SelectMany(o => o.Policies).ToList());
                        var stringConverter = new ResourceCachingNiceStringConverter(resourceCache);
                        return es.Select(e => new DataAccessLogModel(e, stringConverter));
                    });

                var aggregator = new DataAccessLogAggregator();

                logList = aggregator.Aggregate(logs).ToList();
            }
            catch (Exception)
            {
                errMsg = "Impossible to retrieve logs";
                ViewBag.Error = errMsg;
            }

            return View(logList);
        }

        /* Method modified by IT Innovation Centre 2017 */
        public string GetServiceTicket()
        {
            string pdbOSPSId = ConfigurationManager.AppSettings["pdbOSPSId"];
            string ticketGrantingTicket;
            if (Session == null)
            {
                ticketGrantingTicket = System.Web.HttpContext.Current.Session["TGT"] as string;
            }
            else
            {
                ticketGrantingTicket = Session["TGT"] as string;
            }

            return _aapiClient.GetServiceTicket(ticketGrantingTicket, pdbOSPSId);
        }

        public string extractPolicyName(string pText)
        {
            string policyText = pText;
            if (!String.IsNullOrEmpty(policyText))
            {
                var idx = policyText.IndexOf("  ");
                if (idx > 0)
                {
                    policyText = policyText.Substring(0, idx);
                }
            }
            return policyText;
        }

        /* Fetch OSP list and filter it with AAPI authorised OSPs */
        public List<OSPPrivacyPolicy> GetAuthorisedOspList()
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
                OspList ospList = userInstance.OspListGet();
                Debug.Print("OSP LIST: " + ospList.ToString());

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

        public OSPReasonPolicy getPrivacyPolicyAccessReasons(string ospId)
        {
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetServiceTicket());

            var instance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);
            OSPReasonPolicy ospReasonPolicy = null;
            try
            {                
                ospReasonPolicy = instance.OSPOspIdPrivacyPolicyGet(ospId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSPOspIdPrivacyPolicyAccessReasonsGet for " + ospId + ":" + e.Message);
            }
            return ospReasonPolicy;
        }

        /* Method modified by IT Innovation Centre 2016 */
        public ActionResult AccessPreferences()
        {
            List<OSPPrivacyPolicy> availableOSPs = GetAuthorisedOspList();
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
            string selectedOspId = null;

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
                            // update selected osp to first one match found
                            if (String.IsNullOrEmpty(selectedOspId))
                            {
                                selectedOspId = osp.PolicyUrl;
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

            if (Session["QuestionnaireOSP"] != null)
            {
                selectedOspId = Session["QuestionnaireOSP"].ToString();
                Session["QuestionnaireOSP"] = null;
            } else if (String.IsNullOrEmpty(selectedOspId))
            {
                selectedOspId = userSP.ElementAt(0).OspId;
            }

            List <ModOSPConsents> opsModList = GroupAP(userSP, selectedOspId, availableOSPs);
            return View(opsModList);
        }

        private List<ModOSPConsents> GroupAP(List<OSPConsents> consents, string selctedOspId, List<OSPPrivacyPolicy> availableOSPs)
        {
            List<ModOSPConsents> modConsentsList = new List<ModOSPConsents>();

            foreach (OSPConsents cons in consents)
            {
                // get consent propte ospi
                string consOspPolicyId = cons.OspId;
                foreach(var osp in availableOSPs)
                {
                    if(cons.OspId == osp.PolicyUrl)
                    {
                        //consOspPolicyId = osp.PolicyUrl;
                        consOspPolicyId = osp.OspPolicyId;
                        break;
                    }
                }

                // get access reasons
                //OSPReasonPolicy osprp = getPrivacyPolicyAccessReasons(cons.OspId);
                OSPReasonPolicy osprp = getPrivacyPolicyAccessReasons(consOspPolicyId);
                Dictionary<string, string> reasonDict = new Dictionary<string, string>();
                if (osprp != null)
                {
                    foreach (var rp in osprp.Policies)
                    {
                        if (!string.IsNullOrEmpty(rp.Datauser) && !string.IsNullOrEmpty(rp.Datatype))
                        {
                            if (!reasonDict.ContainsKey(rp.Datauser + rp.Datatype))
                            {
                                reasonDict.Add(rp.Datauser + rp.Datatype, rp.Reason);
                            }
                        }
                    }
                    
                }

                ModOSPConsents mod = new ModOSPConsents();
                mod.OspId = cons.OspId;

                mod.OspFriendlyName = cons.OspId;
                // find the osp text since consent object has only the ospId
                foreach(var osp in availableOSPs)
                {
                    if(osp.PolicyUrl == cons.OspId)
                    {
                        string policyText = extractPolicyName(osp.PolicyText);
                        mod.OspFriendlyName = policyText;
                        mod.OspPolicyText = osp.PolicyText;
                        break;
                    }
                }

                if (selctedOspId == cons.OspId)
                {
                    mod.selected = true;
                }

                var resourceCache = new ResourceFriendlyNameCache(cons.AccessPolicies);
                var stringConverter = new ResourceCachingNiceStringConverter(resourceCache);

                var models = cons.AccessPolicies.Select(ap => new AccessPolicyModel(ap, stringConverter)).ToList();

                foreach (AccessPolicyModel model in models)
                {
                    string can = "can";
                    if (!model.Permission)
                    {
                        can = "cannot";
                    }
                    model.TooltipReason = model.Subject + " " + can + " " + model.Action.ToLower() + " " + model.Resource.ToLower();

                    if (reasonDict.ContainsKey(model.Subject + model.Category))
                    {
                        string reason = reasonDict[model.Subject + model.Category];
                        if (!string.IsNullOrEmpty(reason))
                        {
                            model.TooltipReason += " for " + reason;
                            model.Reason = reason;
                        }
                    }
                }
                // List<Grouping<(Subject, Category), Model>>
                var groupBySubjectAndCategory = models.GroupBy(apm => new {apm.Subject, apm.Category});

                // List<Grouping<Subject, Grouping<Category, Model>>>
                mod.AccessPoliciesBySubjectThenCategory = groupBySubjectAndCategory
                    .GroupBy(g => g.Key.Subject, // Pull together groups with same subject to form outer group
                        g => g.GroupBy(apm => apm.Category) // Reorganise inner group as Grouping<Category, Model>
                        .Single()) // Each inner group was already seperated by category
                    .ToList();
                modConsentsList.Add(mod);
            }

            return modConsentsList;
        }
        
        /* Method modified by IT Innovation Centre 2016 */
        [HttpPost]
        public ActionResult AccessPreferences(FormCollection resp)
        {
            Debug.Print("http post here: " + Convert.ToString(resp) + Response);
            List<string> policiesKey = new List<string>();
            string resetOsp = null;
            string removeOsp = null;
            string ospPolicyUrl = null;

            foreach (var key in resp.AllKeys)
            {
                if (key.ToString().StartsWith("qstage_"))
                {                 
                    string ospId = key.ToString().Remove(0, 7);
                    Session["QuestionnaireOSP"] = ospId;
                    return RedirectToAction("PrivacyQuestionnaire");
                }
                else if (key.ToString().StartsWith("reset_"))
                {
                    resetOsp = key.ToString().Remove(0, 6);
                    break;
                }
                else if (key.ToString().StartsWith("remove_"))
                {
                    removeOsp = key.ToString().Remove(0, 7);
                    break;
                }
                //Debug.Print("resp: " + key);
                policiesKey.Add(key);
            }

            if (String.IsNullOrEmpty(resetOsp) && String.IsNullOrEmpty(removeOsp))
            {
                policiesKey.RemoveAt(resp.Count - 1);
                ospPolicyUrl = resp.AllKeys[resp.Count - 1];
            }
            else if (!String.IsNullOrEmpty(removeOsp))
            {
                ospPolicyUrl = removeOsp;
            }

            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetServiceTicket());

            var getInstance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            var putInstance = new eu.operando.core.pdb.cli.Api.PUTApi(configuration);

            var postInstance = new eu.operando.core.pdb.cli.Api.POSTApi(configuration);

            List<OSPPrivacyPolicy> checkedOSPList = GetAuthorisedOspList();
            List<OSPConsents> newSOP = new List<OSPConsents>();
            string selectedOSPID = "";

            // update UPP part by examining selected OSP policies 
            if (!String.IsNullOrEmpty(ospPolicyUrl))
            {
                try
                {
                    OSPPrivacyPolicy selectedOSP = null;

                    // find active (selected) OSP -> selectedOSP, selectedOSPID
                    // with selected policies from form
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
                                string ospKey = string.Concat(string.Concat(ap.Subject.GetHashCode().ToString(), " "),
                                    ap.Resource.GetHashCode().ToString());
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

                    // get user UPP from db, or create a new UPP for user
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

                    // update user subscribed osp policies or add selected one if not found
                    bool found = false;
                    foreach (OSPConsents consent in userUPP.SubscribedOspPolicies)
                    {
                        Debug.Print("checking consent: " + consent.OspId + " vs " + ospPolicyUrl + " vs " +
                                    selectedOSP.PolicyUrl);
                        if (consent.OspId == selectedOSPID)
                        {
                            found = true;
                            Debug.Print("Found matching UPP consent for UPDATE:" + consent.ToString());
                            OSPConsents updateConsent = new OSPConsents();
                            updateConsent.OspId = selectedOSPID;
                            updateConsent.AccessPolicies = selectedOSP.Policies;
                            if (String.IsNullOrEmpty(removeOsp))
                            {
                                newSOP.Add(updateConsent);
                            }
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

                    // update user policy
                    putInstance.UserPrivacyPolicyUserIdPut(username, userUPP);
                }
                catch (Exception e)
                {
                    Debug.Print("Exception when calling pdb-server: " + e.Message);
                }
            }

            //update the OSP selected form
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
                if (String.IsNullOrEmpty(removeOsp))
                {
                    selected = selectedOSPID;
                }
                else
                {
                    selected = checkedOSPList[0].PolicyUrl;
                }
            }
            else
            {
                selected = resetOsp;
            }
            return View(GroupAP(userSP, selected, checkedOSPList));
        }

        public ActionResult PrivacyWizard()
        {
            return View();
        }

        public void deleteUPP(string username)
        {
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetServiceTicket());

            var instance = new eu.operando.core.pdb.cli.Api.DELETEApi(configuration);
            try
            {
                instance.UserPrivacyPolicyUserIdDelete(username);
            }
            catch (Exception ex)
            {
                Debug.Print("Failed to delete UPP for user " + username + " ex: " + ex.Message);
            }            
        }

        public void createUPP(string username)
        {
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetServiceTicket());

            var postInstance = new eu.operando.core.pdb.cli.Api.POSTApi(configuration);

            UserPrivacyPolicy userUPP = new UserPrivacyPolicy();
            userUPP.UserId = username;
            userUPP.SubscribedOspPolicies = new List<OSPConsents>();
            userUPP.SubscribedOspSettings = new List<OSPSettings>();
            userUPP.UserPreferences = new List<UserPreference>();

            try
            {
                postInstance.UserPrivacyPolicyPost(userUPP);
            }
            catch (Exception e)
            {
                Debug.Print("failed to create UPP for " + username + " ex " + e.Message);
            }
        }


        [HttpGet]
        //public async Task<ActionResult> PrivacyQuestionnaire()
        public ActionResult PrivacyQuestionnaire()
        {
            if (Session["QuestionnaireOSP"] == null)
            {
                // redirect to access preferences page
                return RedirectToAction("AccessPreferences", "DataSubject");
            }
            string qUriBase = ConfigurationManager.AppSettings["questionnaireURL"].ToString();
            var qConfiguration = new eu.operando.core.pc.pq.Client.Configuration(new eu.operando.core.pc.pq.Client.ApiClient(qUriBase));
            var getQInstance = new eu.operando.core.pc.pq.Api.QuestionsApi(qConfiguration);
            string ospId = Session["QuestionnaireOSP"].ToString();

            List<OSPPrivacyPolicy> checkedOSPList = GetAuthorisedOspList();
            foreach(var osp in checkedOSPList)
            {
                if(osp.PolicyUrl == ospId)
                {
                    ospId = osp.OspPolicyId;
                    break;
                }
            }

            try
            {                
                List<Questionobject> result = getQInstance.QuestionsUserIdOspIdGet(Session["Username"].ToString(), ospId, "EN");
                Dictionary<string, List<ModQuestionObject>> qnDict = new Dictionary<string, List<ModQuestionObject>>();
                int qId = 1;
                foreach (Questionobject question in result)
                {
                    ModQuestionObject mqObj = new ModQuestionObject();
                    mqObj.qObj = question;
                    mqObj.qId = qId;

                    Debug.Print("Question: " + question.ToString());
                    if (qnDict.ContainsKey(question.Category))
                    {
                        qnDict[question.Category].Add(mqObj);
                    }
                    else
                    {
                        List<ModQuestionObject> qnList = new List<ModQuestionObject>();
                        qnList.Add(mqObj);
                        qnDict.Add(question.Category, qnList);
                    }
                    qId += 1;
                }
                Session["questionnaire"] = qnDict;
                ViewBag.questionnaire = qnDict;
            }
            catch (eu.operando.core.pc.pq.Client.ApiException ex)
            {
                Debug.Print("got pq client exception: " + ex.Message);
            }

            return View();
        }

        
        [HttpPost]
        public ActionResult PrivacyQuestionnaire(FormCollection formCol)
        {
            var res = Response;
            string qUriBase = ConfigurationManager.AppSettings["questionnaireURL"].ToString();
            var qConfiguration = new eu.operando.core.pc.pq.Client.Configuration(new eu.operando.core.pc.pq.Client.ApiClient(qUriBase));
            var postQInstance = new eu.operando.core.pc.pq.Api.QuestionsApi(qConfiguration);
            Dictionary<string, List<ModQuestionObject>> qnDict = Session["questionnaire"] as Dictionary<string, List<ModQuestionObject>>;
            List<Questionobject> answeredQList = new List<Questionobject>();
            try
            {
                foreach (var cat in qnDict)
                {
                    foreach (var modQ in cat.Value)
                    {
                        modQ.qObj.Score = Request.Form["radio" + modQ.qId];
                        answeredQList.Add(modQ.qObj);
                    }
                }

                try
                {
                    postQInstance.QuestionsUserIdOspIdPost(Session["Username"].ToString(), answeredQList);

                    return RedirectToAction("AccessPreferences", "DataSubject");
                }
                catch (eu.operando.core.pc.pq.Client.ApiException ex)
                {
                    Debug.Print("got pq client exception: " + ex.Message);
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (OperationCanceledException) { }
            return View();
        }
    }
}
