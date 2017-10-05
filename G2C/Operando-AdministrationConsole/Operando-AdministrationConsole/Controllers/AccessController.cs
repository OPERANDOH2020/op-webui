using eu.operando.core.pdb.cli.Model;
using eu.operando.interfaces.aapi.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Operando_AdministrationConsole.Controllers
{
    public class AccessController : Controller
    {
        /* Method modified by IT Innovation Centre 2016 */
        // GET: Access
        public ActionResult Login()
        {
            Debug.Print("LVM before:");
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            // Redirect("login page");
            return View();
        }

        public ActionResult Login1(Models.UserAccount user)
        {
            Debug.Print("LVM after:");
            Session["Username"] = "testme";
            Session["TGT"] = "ticket_ticket";
            Session["Usertype"] = "user";
            Session["Fullname"] = "Test Me";
            Session["Email"] = "tets@test.com";
            return RedirectToAction("Index", "Dashboard");
        }
        /* Method modified by IT Innovation Centre 2016 */
        // POST: Access
        [HttpPost]
        public ActionResult Login(Models.UserAccount user)
        {
            Debug.Print("LVM after:");
            string tgtBasePath = ConfigurationManager.AppSettings["aapiBasePath"];
            string userBasePath = ConfigurationManager.AppSettings["userAapiBasePath"];
            
            var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);
            var tgtInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(tgtBasePath);

            try
            {
                UserCredential userCredential = new UserCredential(user.Username, user.Password);
                string ticket = tgtInstance.AapiTicketsPost(userCredential);

                if ((ticket != null) && (ticket.EndsWith("casdotoperandodoteu")))
                {
                    Debug.Print("Got a ticket: " + ticket);
                    Session["Username"] = user.Username;
                    Session["TGT"] = ticket;

                    // get user profile, DISSABLED as server does not fully supports this operation yet
                    var usr = userInstance.UserUsernameGet(user.Username);                    
                    Debug.Print("USER PROFILE:" + usr.ToJson());
                    // UPDATE PROFILE PAGE ...
                    Newtonsoft.Json.Linq.JObject jProfile = Newtonsoft.Json.Linq.JObject.Parse(usr.ToJson());
                    foreach (var attr in jProfile["optionalAttrs"])
                    {
                        if (attr["attrName"].ToString() == "user_type")
                        {
                            Session["Usertype"] = attr["attrValue"].ToString();
                        }
                        if (attr["attrName"].ToString() == "fullname")
                        {
                            Session["Fullname"] = attr["attrValue"].ToString();
                        }
                        if (attr["attrName"].ToString() == "email")
                        {
                            Session["Email"] = attr["attrValue"].ToString();
                        }
                    }

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling: " + e.Message);
            }
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        /* Method modified by IT Innovation Centre 2016 */
        [HttpPost]
        public ActionResult Registration(Models.RegisterViewModel rvm)
        {
            Debug.Print("REGISTRATION: " + rvm.ToString());
            if (ModelState.IsValid)
            {
                Debug.Print("REGISTRATION is valid.");
                ModelState.Clear();
                string userBasePath = ConfigurationManager.AppSettings["aapiBasePath"];
                var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);
                try
                {
                    User user = new User(rvm.Username, rvm.Password);
                    List<eu.operando.interfaces.aapi.Model.Attribute> optAttributes = new List<eu.operando.interfaces.aapi.Model.Attribute>();
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("user_type", rvm.Usertype));
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("fullname", rvm.Fullname));
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("email", rvm.Email));
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("address", rvm.Address));
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("city", rvm.City));
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("country", rvm.Country));
                    user.OptionalAttrs = optAttributes;

                    List<eu.operando.interfaces.aapi.Model.PrivacySetting> privacySettings = new List<eu.operando.interfaces.aapi.Model.PrivacySetting>();
                    privacySettings.Add(new eu.operando.interfaces.aapi.Model.PrivacySetting("string", "string"));
                    user.PrivacySettings = privacySettings;

                    List<eu.operando.interfaces.aapi.Model.Attribute> requiredAttributes = new List<eu.operando.interfaces.aapi.Model.Attribute>();
                    requiredAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("string", "string"));
                    user.RequiredAttrs = requiredAttributes;

                    Debug.Print("USER to registration: " + user.ToJson());

                    // register user
                    var usr = userInstance.AapiUserRegisterPost(user);
                    Debug.Print("USER reg sesponse: " + usr.ToJson());
                }
                catch (Exception e)
                {
                    Debug.Print("Exception when calling: " + e.Message);
                }
                ViewBag.Message = rvm.Username + " successfully registered";

                //return RedirectToAction("Index", "Dashboard");
                return RedirectToAction("Login", "Access");
            }
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        public ActionResult Lock()
        {
            return View();
        }

        public ActionResult AuthenticationRequest()
        {
            var dataSubject = new DataSubjectController();

            List<OSPPrivacyPolicy> availableOSPs = dataSubject.GetAuthorisedOspList();
            ViewBag.ospList = availableOSPs;
            return View();
        }

        /* Method modified by IT Innovation Centre 2016 */
        [HttpPost]
        public ActionResult AuthenticationRequest(Models.RegisterViewModel rvm)
        {
            Debug.Print("REGISTRATION: " + rvm.ToString());
            if (ModelState.IsValid)
            {
                Debug.Print("REGISTRATION is valid.");
                ModelState.Clear();
                string userBasePath = ConfigurationManager.AppSettings["aapiBasePath"];
                var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);
                try
                {
                    User user = new User(rvm.Username, rvm.Password);
                    List<eu.operando.interfaces.aapi.Model.Attribute> optAttributes = new List<eu.operando.interfaces.aapi.Model.Attribute>();
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("user_type", rvm.Usertype));
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("fullname", rvm.Fullname));
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("email", rvm.Email));
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("address", rvm.Address));
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("city", rvm.City));
                    optAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("country", rvm.Country));
                    user.OptionalAttrs = optAttributes;

                    List<eu.operando.interfaces.aapi.Model.PrivacySetting> privacySettings = new List<eu.operando.interfaces.aapi.Model.PrivacySetting>();
                    privacySettings.Add(new eu.operando.interfaces.aapi.Model.PrivacySetting("string", "string"));
                    user.PrivacySettings = privacySettings;

                    List<eu.operando.interfaces.aapi.Model.Attribute> requiredAttributes = new List<eu.operando.interfaces.aapi.Model.Attribute>();
                    requiredAttributes.Add(new eu.operando.interfaces.aapi.Model.Attribute("string", "string"));
                    user.RequiredAttrs = requiredAttributes;

                    Debug.Print("USER to registration: " + user.ToJson());

                    // register user
                    var usr = userInstance.AapiUserRegisterPost(user);
                    Debug.Print("USER reg sesponse: " + usr.ToJson());

                    // create an empty UPP
                    var dataSubject = new DataSubjectController();
                    List<OSPPrivacyPolicy> availableOSPs = dataSubject.GetAuthorisedOspList();
                    OSPPrivacyPolicy selectedOSP = null;
                    foreach(var osp in availableOSPs)
                    {
                        if(osp.PolicyUrl == rvm.Osp)
                        {
                            selectedOSP = osp;
                            break;
                        }
                    }
                    string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
                    string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];
                    
                    var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
                    configuration.AddDefaultHeader(stHeaderName, dataSubject.GetServiceTicket());

                    //var getInstance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);
                                        
                    var postInstance = new eu.operando.core.pdb.cli.Api.POSTApi(configuration);

                    OSPConsents newConsent = new OSPConsents();
                    newConsent.OspId = selectedOSP.PolicyUrl;
                    newConsent.AccessPolicies = selectedOSP.Policies;

                    UserPrivacyPolicy userUPP = new UserPrivacyPolicy();
                    userUPP.UserId = rvm.Username;
                    userUPP.SubscribedOspPolicies = new List<OSPConsents>() { newConsent };
                    userUPP.SubscribedOspSettings = new List<OSPSettings>();
                    userUPP.UserPreferences = new List<UserPreference>();
                    postInstance.UserPrivacyPolicyPost(userUPP);
                }
                catch (Exception e)
                {
                    Debug.Print("Exception when calling: " + e.Message);
                }
                ViewBag.Message = rvm.Username + " successfully registered";

                return RedirectToAction("Index", "Dashboard");
                //return RedirectToAction("Login", "Access");
            }
            return View();
        }
    }
}