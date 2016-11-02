using eu.operando.interfaces.aapi.Model;
using System;
using System.Collections.Generic;
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
            return View();
        }

        /* Method modified by IT Innovation Centre 2016 */
        // POST: Access
        [HttpPost]
        public ActionResult Login(Models.UserAccount user)
        {
            Debug.Print("LVM after:");
            string tgtBasePath = "http://snf-706921.vm.okeanos.grnet.gr:8080/authentication";
            string userBasePath = "http://snf-706921.vm.okeanos.grnet.gr:8080/authentication/aapi";
            var tgtInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(tgtBasePath);
            var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);

            try
            {
                UserCredential userCredential = new UserCredential(user.Username, user.Password);
                string ticket = tgtInstance.AapiTicketsPost(userCredential);

                if ((ticket != null) && (ticket.EndsWith("casdotoperandodoteu")))
                {
                    Debug.Print("Got a ticket: " + ticket);
                    Session["Username"] = user.Username;
                    Session["TGT"] = ticket;
                    Session["Usertype"] = "normal-user";

                    // get user profile, DISSABLED as server does not fully supports this operation yet
                    // var usr = userInstance.UserUsernameGet(user.Username);
                    // Debug.Print("USER PROFILE:" + usr.ToJson());
                    // UPDATE PROFILE PAGE ...

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
                string userBasePath = "http://snf-706921.vm.okeanos.grnet.gr:8080/authentication";
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
    }
}