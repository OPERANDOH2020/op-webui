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
using System.Configuration;
using eu.operando.core.ldb;
using eu.operando.core.ldb.Model;
using Operando_AdministrationConsole.Helper;
using Operando_AdministrationConsole.Models.DataSubjectModels;

namespace Operando_AdministrationConsole.Controllers
{

    public class DataSubjectController : Controller
    {
        private readonly ILdbClient _ldbClient;

        public string errMsg = String.Empty;

        public DataSubjectController()
        {
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

        private string getServiceTicket()
        {
            string st = "";
            string pdbOSPSId = ConfigurationManager.AppSettings["pdbOSPSId"];

            // get OSP service ticket
            string aapiBasePath = ConfigurationManager.AppSettings["aapiBasePath"];
            var aapiInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(aapiBasePath);

            try
            {
                // OSP service ticket call
                st = aapiInstance.AapiTicketsTgtPost(Session["TGT"].ToString(), pdbOSPSId);
                Debug.Print("Got PDB ST: " + st);
            }
            catch (eu.operando.interfaces.aapi.Client.ApiException ex)
            {
                Debug.Print("Exception failed to make API call to AapiTicketsTgtPost: " + ex.Message);
            }

            return st;
        }

        /* Method modified by IT Innovation Centre 2016 */
        public ActionResult AccessPreferences()
        {
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, getServiceTicket());
            
            var instance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            try
            {
                // OSP call to get the list of service providers
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
            
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, getServiceTicket());            
            
            var getInstance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            var putInstance = new eu.operando.core.pdb.cli.Api.PUTApi(configuration);

            var postInstance = new eu.operando.core.pdb.cli.Api.POSTApi(configuration);

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