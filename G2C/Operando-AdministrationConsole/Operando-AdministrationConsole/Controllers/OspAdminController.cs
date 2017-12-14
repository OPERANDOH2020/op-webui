using Operando_AdministrationConsole.Helper;
using Operando_AdministrationConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SharpConnect.MySql;
using SharpConnect.MySql.SyncPatt;
using System.Configuration;
using System.Net.Http;
using System.Text;
using eu.operando.common.Services;
using eu.operando.core.bda;
using eu.operando.core.bda.Model;
using Operando_AdministrationConsole.Models.OspAdminModels;
using System.Diagnostics;
using eu.operando.core.pdb.cli.Model;
using Newtonsoft.Json;
using eu.operando.interfaces.aapi;
using eu.operando.interfaces.aapi.Model;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace Operando_AdministrationConsole.Controllers
{
    public class OspAdminController : Controller
    {
        private OperandoWebServiceHelper helper = new OperandoWebServiceHelper();
        ReportManagerOSP reportManagerOSP = new ReportManagerOSP();


        private readonly IBdaClient _bdaClient;
        private readonly IAapiClient _aapiClient;

        public OspAdminController()
        {
            _bdaClient = new BdaClient();
            _aapiClient = new AapiClient();
        }

        private Uri OSPRoot(string id)
        {
            //return new Uri($"http://localhost:8080/stub-pdb/api/OSP/{id}/privacy-policy");
            return new Uri($"http://10.136.24.87:8080/pdb/OSP/587f80549e86b2c3b0a43eaa/privacy-policy");
        }

        public ActionResult ControllerDownloadAction(string fileName)
        {
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment;filename="+ fileName);
            Response.Clear();
            Response.WriteFile(Server.MapPath("../" + ConfigurationManager.AppSettings["reportSavePath"] + "/" + fileName));
            Response.Flush();
            Response.End();
            return View();
        }

        private eu.operando.core.pdb.cli.Client.Configuration getConfiguration(string serviceIdKey)
        {
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];
            string pdbOSPSId = ConfigurationManager.AppSettings[serviceIdKey];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetUppServiceTicket(pdbOSPSId));

            return configuration;
        }
        public List<OSPPrivacyPolicy> GetOspList()
        {
            string userBasePath = ConfigurationManager.AppSettings["userAapiBasePath"];
            var userInstance = new eu.operando.interfaces.aapi.Api.DefaultApi(userBasePath);
            
            var instance = new eu.operando.core.pdb.cli.Api.GETApi(getConfiguration("pdbOSPSId"));

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
                if (checkedOSPList.Count == 0)
                {
                    checkedOSPList = response;
                }
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSP list: " + e.Message);
            }
            return checkedOSPList;
        }
        public ActionResult PrivacyPolicy()
        {
            var instance = new eu.operando.core.pdb.cli.Api.GETApi(getConfiguration("pdbOSPSId"));

            List<OSPPrivacyPolicy> ospList = GetOspList();
            List<OSPReasonPolicy> reasonPolicyList = new List<OSPReasonPolicy>();
            foreach (OSPPrivacyPolicy osp in ospList)
            {
                OSPReasonPolicy ospReasonPolicy = null;
                try
                {                    
                    ospReasonPolicy = instance.OSPOspIdPrivacyPolicyGet(osp.OspPolicyId);
                    ospReasonPolicy.OspPolicyId = osp.PolicyUrl;       
                }
                catch (eu.operando.core.pdb.cli.Client.ApiException e)
                {
                    ospReasonPolicy = new OSPReasonPolicy();
                    ospReasonPolicy.OspPolicyId = osp.PolicyUrl; // ospId;
                    ospReasonPolicy.Policies = new List<AccessReason>();
                }

                reasonPolicyList.Add(ospReasonPolicy);
                // just return first osp for testing only
                // break;
            }
            return View(reasonPolicyList);
            //return View();
        }

        [HttpPost]
        public ActionResult NewPrivacyPolicy(OSPReasonPolicy policy)
        {
            var instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            OSPReasonPolicyInput ospRPI = new OSPReasonPolicyInput();
            ospRPI.Policies = policy.Policies;

            instance.OSPOspIdPrivacyPolicyPut(policy.OspPolicyId, ospRPI);

            return View(policy);
        }

        public ActionResult UpdatePolicy()
        {
            return View();
        }
        /*Method created by IT Innovation Centre, Christopher Coles, 06/09/2017*/
        public PartialViewResult DisplayRecords()
        {
            var instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            List<OSPPrivacyPolicy> ospList = GetOspList();
           

            HashSet<string> roles = new HashSet<string>();
            foreach (var item in ospList[0].Policies)
            {
                roles.Add(item.Subject);
            }


            //links the accessPolicies and the subjects in a dictionary
            Dictionary<string, List<AccessPolicy>> roleDictionary = new Dictionary<string, List<AccessPolicy>>();
            foreach (var role in roles)
            {
                List<AccessPolicy> policyList = new List<AccessPolicy>();
                roleDictionary.Add(role, policyList);
            }
            foreach (var policy in ospList[0].Policies)
            {
                foreach (var role in roles)
                {

                    if (policy.Subject.Equals(role))
                    {
                        List<AccessPolicy> policyList = roleDictionary[role];
                        if (!(policyList.Contains(policy)))
                        {
                            policyList.Add(policy);
                        }


                    }
                }
            }
            //link the resources to the roles
            Dictionary<string, HashSet<string>> roleResourceDictionary = new Dictionary<string, HashSet<string>>();
            foreach (var role in roles)
            {
                HashSet<string> resourcesHashSet = new HashSet<string>();
                roleResourceDictionary.Add(role, resourcesHashSet);
            }
            foreach (var policy in ospList[0].Policies)
            {
                foreach (var role in roles)
                {

                    if (policy.Subject.Equals(role))
                    {
                        HashSet<string> resourcesHashSet = roleResourceDictionary[role];
                        resourcesHashSet.Add(policy.Resource);
                    }
                }
            }
            //create a list of all the possible actions
            List<AccessPolicy.ActionEnum> actionList = new List<AccessPolicy.ActionEnum>();


            actionList.Add(AccessPolicy.ActionEnum.Collect);
            actionList.Add(AccessPolicy.ActionEnum.Create);
            actionList.Add(AccessPolicy.ActionEnum.Delete);
            actionList.Add(AccessPolicy.ActionEnum.Update);
            actionList.Add(AccessPolicy.ActionEnum.Access);
            actionList.Add(AccessPolicy.ActionEnum.Use);
            actionList.Add(AccessPolicy.ActionEnum.Disclose);
            actionList.Add(AccessPolicy.ActionEnum.Archive);

            ViewBag.ospList = ospList;
            ViewBag.osp = ospList[0];
            ViewBag.roleResourceDictionary = roleResourceDictionary;
            ViewBag.roles = roles;
            ViewBag.actionList = actionList;
            ViewBag.roleDictionary = roleDictionary;
            return PartialView("_RecordPage");
        }
        /*Method created by IT Innovation Centre, Christopher Coles, 06/09/2017*/
        [HttpPut]
        public void updateAccessPolicy(string[] rolearr, string[] resourcearr, string[] collectarr, string[] createarr, string[] deletearr, string[] updatearr, string[] accessarr, string[] usearr, string[] disclosearr, string[] archivearr)
        {

           var  instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            List<OSPPrivacyPolicy> ospList = GetOspList();
            HashSet<string> roles = new HashSet<string>();
            List<AccessPolicy> policiesToRemove = new List<AccessPolicy>();
            //loops through all the rows from the table on the record page to generate or update policies
            for (int i = 0; i < rolearr.Length; i++)
            {
                string roleInput = rolearr[i];
                string resource = resourcearr[i];
                string collect = collectarr[i];
                string create = createarr[i];
                string delete = deletearr[i];
                string update = updatearr[i];
                string access = accessarr[i];
                string use = usearr[i];
                string disclose = disclosearr[i];
                string archive = archivearr[i];
                if (collect.Equals("True"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Collect, true);
                }
                else if (collect.Equals("False"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Collect, false);
                }
                else if (collect.Equals("Ignore"))
                {
                    foreach (var policy in ospList[0].Policies)
                    {
                        if (policy.Action.Equals(AccessPolicy.ActionEnum.Collect) && policy.Subject.Equals(roleInput) && policy.Resource.Equals(resource))
                        {
                            policiesToRemove.Add(policy);
                        }
                    }

                }

                if (create.Equals("True"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Create, true);
                }
                else if (create.Equals("False"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Create, false);
                }
                else if (create.Equals("Ignore"))
                {
                    foreach (var policy in ospList[0].Policies)
                    {
                        if (policy.Action.Equals(AccessPolicy.ActionEnum.Create) && policy.Subject.Equals(roleInput) && policy.Resource.Equals(resource))
                        {
                            policiesToRemove.Add(policy);
                        }
                    }

                }

                if (delete.Equals("True"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Delete, true);
                }
                else if (delete.Equals("False"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Delete, false);
                }
                else if (delete.Equals("Ignore"))
                {
                    foreach (var policy in ospList[0].Policies)
                    {
                        if (policy.Action.Equals(AccessPolicy.ActionEnum.Delete) && policy.Subject.Equals(roleInput) && policy.Resource.Equals(resource))
                        {
                            policiesToRemove.Add(policy);
                        }
                    }

                }

                if (update.Equals("True"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Update, true);
                }
                else if (update.Equals("False"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Update, false);
                }
                else if (update.Equals("Ignore"))
                {
                    foreach (var policy in ospList[0].Policies)
                    {
                        if (policy.Action.Equals(AccessPolicy.ActionEnum.Update) && policy.Subject.Equals(roleInput) && policy.Resource.Equals(resource))
                        {
                            policiesToRemove.Add(policy);
                        }
                    }

                }

                if (access.Equals("True"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Access, true);
                }
                else if (access.Equals("False"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Access, false);
                }
                else if (access.Equals("Ignore"))
                {
                    foreach (var policy in ospList[0].Policies)
                    {
                        if (policy.Action.Equals(AccessPolicy.ActionEnum.Access) && policy.Subject.Equals(roleInput) && policy.Resource.Equals(resource))
                        {
                            policiesToRemove.Add(policy);
                        }
                    }

                }

                if (use.Equals("True"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Use, true);
                }
                else if (use.Equals("False"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Use, false);
                }
                else if (use.Equals("Ignore"))
                {
                    foreach (var policy in ospList[0].Policies)
                    {
                        if (policy.Action.Equals(AccessPolicy.ActionEnum.Use) && policy.Subject.Equals(roleInput) && policy.Resource.Equals(resource))
                        {
                            policiesToRemove.Add(policy);
                        }
                    }

                }

                if (disclose.Equals("True"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Disclose, true);
                }
                else if (disclose.Equals("False"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Disclose, false);
                }
                else if (disclose.Equals("Ignore"))
                {
                    foreach (var policy in ospList[0].Policies)
                    {
                        if (policy.Action.Equals(AccessPolicy.ActionEnum.Disclose) && policy.Subject.Equals(roleInput) && policy.Resource.Equals(resource))
                        {
                            policiesToRemove.Add(policy);
                        }
                    }

                }

                if (archive.Equals("True"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Archive, true);
                }
                else if (archive.Equals("False"))
                {
                    updatePolicyPermission(ospList[0], roleInput, resource, AccessPolicy.ActionEnum.Archive, false);
                }
                else if (archive.Equals("Ignore"))
                {
                    foreach (var policy in ospList[0].Policies)
                    {
                        if (policy.Action.Equals(AccessPolicy.ActionEnum.Archive) && policy.Subject.Equals(roleInput) && policy.Resource.Equals(resource))
                        {
                            policiesToRemove.Add(policy);
                        }
                    }

                }
            }
            //remove unneeded policies
            foreach (var policy in policiesToRemove)
            {
                ospList[0].Policies.Remove(policy);
            }
            //put to pdb
            OSPPrivacyPolicyInput input = new OSPPrivacyPolicyInput();
            input.PolicyUrl = ospList[0].PolicyUrl;
            input.PolicyText = ospList[0].PolicyText;
            input.Workflow = ospList[0].Workflow;
            input.Policies = ospList[0].Policies;
            instance.OSPOspIdPut(ospList[0].OspPolicyId, input);

        }



        /*Method created by IT Innovation Centre, Christopher Coles, 06/09/2017*/
        public void updatePolicyPermission(OSPPrivacyPolicy osp, string roleInput, string resource, AccessPolicy.ActionEnum actionEnum, bool permission)
        {
            //updates the policy,  based on the selection from the dropdowns
            bool updated = false;
            foreach (var policy in osp.Policies)
            {
                if (policy.Action.Equals(actionEnum) && policy.Subject.Equals(roleInput) && policy.Resource.Equals(resource))
                {
                    policy.Permission = permission;
                    updated = true;
                    break;
                }
            }
            //creates a new policy if one doesn't already exist
            if (!updated)
            {
                osp.Policies.Add(new AccessPolicy(roleInput, permission, actionEnum, resource, null));
            }
        }

        [HttpPut]
        public void addRole(string OspPolicyId, string role)
        {
            var instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            List<OSPPrivacyPolicy> ospList = GetOspList();
            OSPPrivacyPolicy correctOsp = new OSPPrivacyPolicy();
            //finds the maching osp for the one being edited on the page
            foreach (var osp in ospList)
            {
                if (osp.OspPolicyId.Equals(OspPolicyId))
                {
                    correctOsp = osp;
                }
            }

            List<AccessPolicy> policiesToAdd = new List<AccessPolicy>();
            //gets all the existing resources to add to he new role
            HashSet<string> resources = new HashSet<string>();
            foreach (var policy in correctOsp.Policies)
            {
                resources.Add(policy.Resource);
            }
            //has to add a 'false' permission for the resource to show up
            //creates a meaningless resource in case none exist
            if(resources.Count == 0)
            {
                AccessPolicy newPolicy = new AccessPolicy();
                newPolicy.Action = AccessPolicy.ActionEnum.Access;
                newPolicy.Attributes = null;
                newPolicy.Permission = false;
                newPolicy.Resource = "temporary (remove once other resources are added)";
                newPolicy.Subject = role;
                policiesToAdd.Add(newPolicy);
            }
            foreach (string resource in resources)
            {
                AccessPolicy newPolicy = new AccessPolicy();
                newPolicy.Action = AccessPolicy.ActionEnum.Access;
                newPolicy.Attributes = null;
                newPolicy.Permission = false;
                newPolicy.Resource = resource;
                newPolicy.Subject = role;
                policiesToAdd.Add(newPolicy);

            }
            //adds the new policies
            correctOsp.Policies.AddRange(policiesToAdd);
            //put to pdb
            OSPPrivacyPolicyInput input = new OSPPrivacyPolicyInput();
            input.PolicyUrl = correctOsp.PolicyUrl;
            input.PolicyText = correctOsp.PolicyText;
            input.Workflow = correctOsp.Workflow;
            input.Policies = correctOsp.Policies;
            instance.OSPOspIdPut(correctOsp.OspPolicyId, input);
        }
        [HttpPut]
        public void removeRole(string OspPolicyId, string role)
        {
            var instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            List<OSPPrivacyPolicy> ospList = GetOspList();
            OSPPrivacyPolicy correctOsp = new OSPPrivacyPolicy();
            //finds the maching osp for the one being edited on the page
            foreach (var osp in ospList)
            {
                if (osp.OspPolicyId.Equals(OspPolicyId))
                {
                    correctOsp = osp;
                }
            }

            List<AccessPolicy> policiesToRemove = new List<AccessPolicy>();
            //finds all the policies that match the role to be removed and adds them to be removed
            foreach (var policy in correctOsp.Policies)
            {
                if (policy.Subject.Equals(role))
                {
                    policiesToRemove.Add(policy);
                }
            }
            foreach(var policy in policiesToRemove)
            {
                correctOsp.Policies.Remove(policy);
            }
            //put to pdb
            OSPPrivacyPolicyInput input = new OSPPrivacyPolicyInput();
            input.PolicyUrl = correctOsp.PolicyUrl;
            input.PolicyText = correctOsp.PolicyText;
            input.Workflow = correctOsp.Workflow;
            input.Policies = correctOsp.Policies;
            instance.OSPOspIdPut(correctOsp.OspPolicyId, input);
        }
        [HttpPut]
        //lets the xml be passed through ajax to controller
        [ValidateInput(false)]
        public void addRecord(string OspPolicyId, string odatainput)
        {
            var instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            List<OSPPrivacyPolicy> ospList = GetOspList();
            OSPPrivacyPolicy correctOsp = new OSPPrivacyPolicy();
            foreach (var osp in ospList)
            {
                if (osp.OspPolicyId.Equals(OspPolicyId))
                {
                    correctOsp = osp;
                }
            }
            //gets all the roles in the database to add the new roles to each one
            HashSet<string> roles = new HashSet<string>();
            foreach (var item in correctOsp.Policies)
            {
                roles.Add(item.Subject);
            }
            //serializer used to read in the xml (odata) stream and deserialize it to an object to represent this data 
            XmlSerializer serializer = new XmlSerializer(typeof(EntityType));
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(odatainput);
            writer.Flush();
           stream.Position = 0;
            //the object for which the odata is stored in
            //EntityType objec stored under OspAdmin models
           EntityType odata = (EntityType) serializer.Deserialize(stream);
         
            
            foreach (string role in roles)
            {
                foreach (Property property in odata.Property)
                {

                    AccessPolicy newPolicy = new AccessPolicy();
                    newPolicy.Subject = role;
                    newPolicy.Resource = property.Name;
                    newPolicy.Permission = false;
                    newPolicy.Action = AccessPolicy.ActionEnum.Access;
                    newPolicy.Attributes = null;
                    correctOsp.Policies.Add(newPolicy);

                }
            }
            //put to pdb
            OSPPrivacyPolicyInput input = new OSPPrivacyPolicyInput();
            input.PolicyUrl = correctOsp.PolicyUrl;
            input.PolicyText = correctOsp.PolicyText;
            input.Workflow = correctOsp.Workflow;
            input.Policies = correctOsp.Policies;
            instance.OSPOspIdPut(correctOsp.OspPolicyId, input);
        }
        /*Method created by IT Innovation Centre, Christopher Coles, 06/09/2017*/
        [HttpPut]
        public void addResource(string OspPolicyId, string resource)
        {
            var instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            List<OSPPrivacyPolicy> ospList = GetOspList();
            OSPPrivacyPolicy correctOsp = new OSPPrivacyPolicy();
            foreach (var osp in ospList)
            {
                if (osp.OspPolicyId.Equals(OspPolicyId))
                {
                    correctOsp = osp;
                }
            }
            //finds all the roles (subjects) for this OSP
            HashSet<string> roles = new HashSet<string>();
            foreach (var item in correctOsp.Policies)
            {
                roles.Add(item.Subject);
            }
            //adds the resource to every role
            foreach(string role in roles)
            {
                AccessPolicy newPolicy = new AccessPolicy();
                newPolicy.Subject = role;
                newPolicy.Resource = resource;
                newPolicy.Permission = false;
                newPolicy.Action = AccessPolicy.ActionEnum.Access;
                newPolicy.Attributes = null;       
                correctOsp.Policies.Add(newPolicy);
            }
            //put to pdb
            OSPPrivacyPolicyInput input = new OSPPrivacyPolicyInput();
            input.PolicyUrl = correctOsp.PolicyUrl;
            input.PolicyText = correctOsp.PolicyText;
            input.Workflow = correctOsp.Workflow;
            input.Policies = correctOsp.Policies;
            instance.OSPOspIdPut(correctOsp.OspPolicyId, input);
        }
        /*Method created by IT Innovation Centre, Christopher Coles, 06/09/2017*/
        public PartialViewResult DisplayCategories()
        {
            var instance = new eu.operando.core.pdb.cli.Api.GETApi(getConfiguration("pdbOSPSId"));

            List<OSPPrivacyPolicy> ospList = GetOspList();
            List<OSPReasonPolicy> reasonPolicyList = new List<OSPReasonPolicy>();
            //get the reason policies for each osp
            foreach (OSPPrivacyPolicy osp in ospList)
            {
                OSPReasonPolicy ospReasonPolicy = null;
                try
                {
                    ospReasonPolicy = instance.OSPOspIdPrivacyPolicyGet(osp.PolicyUrl);
                }
                catch (eu.operando.core.pdb.cli.Client.ApiException e)
                {
                    ospReasonPolicy = new OSPReasonPolicy();
                    ospReasonPolicy.OspPolicyId = osp.PolicyUrl;            
                    ospReasonPolicy.Policies = new List<AccessReason>();
                }

                reasonPolicyList.Add(ospReasonPolicy);
            }   
            ViewBag.ospList = ospList;
            
            ViewBag.reasonPolicies = reasonPolicyList;
            return PartialView("_CategoryPage");
        }
        /*Method created by IT Innovation Centre, Christopher Coles, 06/09/2017*/
        [HttpPut]
        public void updateAccessPolicyCategory(string[] resourcearr, string[] categoryarr)
        {
            var instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            List<OSPPrivacyPolicy> ospList = GetOspList();
           
            List<PolicyAttribute> attributesToRemove = new List<PolicyAttribute>();
            
            foreach (OSPPrivacyPolicy osp in ospList)
            {
                for (int i = 0; i < resourcearr.Length; i++)
                {
                    string resource = resourcearr[i];
                    string category = categoryarr[i]; 
                    foreach (var accessPolicy in osp.Policies)
                    {
                        //boolean stays false if there isn't already an attribute available to be altered
                        bool finished = false;
                        if (accessPolicy.Resource.Equals(resource))
                        {
                            foreach (var attribute in accessPolicy.Attributes)
                            {
                                //changes null attributes to category attributes
                                if (attribute.AttributeName == null)
                                {
                                    attribute.AttributeName = "Category";
                                    attribute.AttributeValue = category;
                                    finished = true;
                                }
                                else
                                {
                                    //updates an existing category attribute
                                    if (attribute.AttributeName.Equals("Category"))
                                    {
                                        attribute.AttributeValue = category;
                                        finished = true;
                                    }
                                }
                            }
                            if (!finished)
                            {
                                accessPolicy.Attributes.Add(new PolicyAttribute("Category", category));
                            }
                        }
                    }
                }
                //put to pdb
                OSPPrivacyPolicyInput input = new OSPPrivacyPolicyInput();
                input.PolicyUrl = osp.PolicyUrl;
                input.PolicyText = osp.PolicyText;
                input.Workflow = osp.Workflow;
                input.Policies = osp.Policies;
                instance.OSPOspIdPut(osp.OspPolicyId, input);
            }
        }
        /*Method created by IT Innovation Centre, Christopher Coles, 06/09/2017*/
        [HttpDelete]
        public void deleteAccessPolicyCategory(){
            var instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            List<OSPPrivacyPolicy> ospList = GetOspList();
            foreach (OSPPrivacyPolicy osp in ospList)
            {
                //goes through each policy and removes all the attributes which have the name 'category'
                    foreach (AccessPolicy accessPolicy in osp.Policies)
                    {
                    List<PolicyAttribute> attributesToRemove = new List<PolicyAttribute>();
                        foreach (var attribute in accessPolicy.Attributes)
                        {
                        if (attribute.AttributeName.Equals("Category"))
                        {
                            attributesToRemove.Add(attribute);
                        }
                        }
                        foreach(var attribute in attributesToRemove)
                    {
                        accessPolicy.Attributes.Remove(attribute);
                    }
                    }
                //put to pdb
                 OSPPrivacyPolicyInput input = new OSPPrivacyPolicyInput();
                    input.PolicyUrl = osp.PolicyUrl;
                    input.PolicyText = osp.PolicyText;
                    input.Workflow = osp.Workflow;
                    input.Policies = osp.Policies;
                    instance.OSPOspIdPut(osp.OspPolicyId, input);
                
            }
           
        }
        [HttpPut]
        public ActionResult UpdatePrivacyPolicy(OSPReasonPolicy policy)
        {
            var instance = new eu.operando.core.pdb.cli.Api.PUTApi(getConfiguration("pdbOSPSId"));
            OSPReasonPolicyInput ospRPI = new OSPReasonPolicyInput();
            ospRPI.Policies = policy.Policies;
            List<OSPPrivacyPolicy> ospList = GetOspList();
            OSPPrivacyPolicy matchingOsp = ospList.Where(o => o.PolicyUrl.Equals(policy.OspPolicyId)).First();

            instance.OSPOspIdPrivacyPolicyPut(matchingOsp.OspPolicyId, ospRPI);

            return Content(policy.ToString());
        }
        

        [HttpDelete]
        public async Task<ActionResult> DeletePrivacyPolicy(OSPReasonPolicy policy)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent OperandoJson = new StringContent(new JsonHelper().SerializeJsonFollowingOperandoConventions(policy), Encoding.UTF8, "application/json");
                var result = await client.PutAsync(OSPRoot(policy.OspPolicyId), OperandoJson);
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRegulation(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.DeleteAsync(OSPRoot(id));
                Response.StatusCode = (int)result.StatusCode;
                return Content(await result.Content.ReadAsStringAsync());
            }
        }

        public ActionResult Reports()
        {
            // creo gli oggetti per popolare la pagina
            reportManagerOSP.reportsObj = new ReportsOSP();
            reportManagerOSP.resultsObj = new ResultsOSP();
            reportManagerOSP.schedulesObj = new SchedulesOSP();


            MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);

            // creo la lista dei report
            ReportsOSP reports = new ReportsOSP();
            reportManagerOSP.reportsObj.ReportList = new List<ReportsOSP>();

            MySqlCommand cmd = null;

            try
            {

                connection.Open();

                String sql = "select * from t_report_mng_list ";

                cmd = new MySqlCommand(sql,connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        ReportsOSP report = new ReportsOSP();

                        if (reader.IsDBNull(0) == false)
                            report.Report = reader.GetString(0);
                        else
                            report.Report = null;

                        if (reader.IsDBNull(1) == false)
                            report.Description = reader.GetString(1);
                        else
                            report.Description = null;

                        if (reader.IsDBNull(2) == false)
                            report.Version = reader.GetString(2);
                        else
                            report.Version = null;

                        if (reader.IsDBNull(3) == false)
                            report.Location = reader.GetString(3);
                        else
                            report.Location = null;

                        if (reader.IsDBNull(4) == false)
                            report.Parameters = reader.GetString(4);
                        else
                            report.Parameters = null;

                        if (reader.IsDBNull(5) == false)
                            report.OSPs = reader.GetString(5).Split(',');
                        else
                            report.OSPs = new String[0];

                        if (reader.IsDBNull(6) == false)
                            report.ID = reader.GetInt32(6);
                        else
                            report.ID = 0;

                        report.OSPsOption = "ASLBG-GASLINI".Split('-');
                        for (int i = 0; i < report.OSPsOption.Length; i++)
                        {
                            string selected = "";
                            for (int r = 0; r < report.OSPs.Length; r++)
                            {
                                if (report.OSPsOption[i] == report.OSPs[r])
                                    selected = "selected";
                            }
                            report.OSPsOption[i] = "<option " + selected + ">" + report.OSPsOption[i] + "</option>";
                        }

                        reportManagerOSP.reportsObj.ReportList.Add(report);
                    }
                    reader.Close();

                }
                catch (Exception e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            connection.Close();


            // creo la lista dei result
            reportManagerOSP.resultsObj.ResultList = new List<ResultsOSP>();

            try
            {

                connection.Open();

                String sql = "select * from t_report_mng_results ";

                cmd = new MySqlCommand(sql, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        ResultsOSP results = new ResultsOSP();

                        if (reader.IsDBNull(0) == false)
                            results.ID = reader.GetInt32(0);
                        else
                            results.ID = 0;

                        if (reader.IsDBNull(1) == false)
                            results.ExecutionDate = reader.GetDateTime(1);
                        else
                            results.ExecutionDate = DateTime.MinValue;

                        if (reader.IsDBNull(2) == false)
                            results.Report = reader.GetString(2);
                        else
                            results.Report = null;

                        if (reader.IsDBNull(3) == false)
                            results.ReportDescription = reader.GetString(3);
                        else
                            results.ReportDescription = null;

                        if (reader.IsDBNull(4) == false)
                            results.ReportVersion = reader.GetString(4);
                        else
                            results.ReportVersion = null;

                        if (reader.IsDBNull(5) == false)
                            results.OSPs = reader.GetString(5).Split(',');
                        else
                            results.OSPs = new String[0];

                        if (reader.IsDBNull(6) == false)
                            results.FileName = reader.GetString(6);
                        else
                            results.FileName = null;

                        reportManagerOSP.resultsObj.ResultList.Add(results);
                    }
                    reader.Close();

                }
                catch (Exception e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            connection.Close();

            // creo la lista dei result
            reportManagerOSP.schedulesObj.ScheduleList = new List<SchedulesOSP>();

            try
            {

                connection.Open();

                String sql = @"select A.Report, LR.Lastrun, NS.NextScheduled 
                                    from t_report_mng_schedules A
                                    join (select report, MAX(Lastrun) as Lastrun from t_report_mng_schedules Group By Report) LR ON LR.report = A.report
                                    join (select report, MIN(NextScheduled) as NextScheduled from t_report_mng_schedules Group By Report) NS ON NS.report = A.report
                                    Group By A.Report";

                cmd = new MySqlCommand(sql, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        SchedulesOSP schedule = new SchedulesOSP();

                        if (reader.IsDBNull(0) == false)
                            schedule.Report = reader.GetString(0);
                        else
                            schedule.Report = null;

                        schedule.OSPsOption = "ASLBG-GASLINI".Split('-');
                        for (int i = 0; i < schedule.OSPsOption.Length; i++)
                        {
                            schedule.OSPsOption[i] = "<option >" + schedule.OSPsOption[i] + "</option>";
                        }

                        schedule.RepeatEveryTypeOption = "DAY(s)-WEEK(s)-MONTH(s)-YEAR(s)".Split('-');

                        for (int i = 0; i < schedule.RepeatEveryTypeOption.Length; i++)
                        {
                            schedule.RepeatEveryTypeOption[i] = "<option >" + schedule.RepeatEveryTypeOption[i] + "</option>";
                        }

                        schedule.DayOfWeekOption = "Mon-Tue-Wed-Thu-Fri-Sat-Sun".Split('-');

                        for (int i = 0; i < schedule.DayOfWeekOption.Length; i++)
                        {
                            schedule.DayOfWeekOption[i] = "<option >" + schedule.DayOfWeekOption[i] + "</option>";
                        }

                        schedule.StoragePeriodTypeOption = "DAY(s)-WEEK(s)-MONTH(s)-YEAR(s)".Split('-');

                        for (int i = 0; i < schedule.StoragePeriodTypeOption.Length; i++)
                        {
                            schedule.StoragePeriodTypeOption[i] = "<option >" + schedule.StoragePeriodTypeOption[i] + "</option>";
                        }

                        if (reader.IsDBNull(1) == false)
                            schedule.LastRun = reader.GetDateTime(1);
                        else
                            schedule.LastRun = DateTime.MinValue;

                        if (reader.IsDBNull(2) == false)
                            schedule.NextScheduled = reader.GetDateTime(2);
                        else
                            schedule.NextScheduled = DateTime.MinValue;

                        reportManagerOSP.schedulesObj.ScheduleList.Add(schedule);
                    }
                    reader.Close();

                }
                catch (Exception e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                         + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            connection.Close();


            // creo la lista dei result
            reportManagerOSP.schedulesObj.ScheduleDetailsList = new List<SchedulesOSP>();

            try
            {

                connection.Open();

                String sql = "select * from t_report_mng_schedules";

                cmd = new MySqlCommand(sql, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        SchedulesOSP schedule = new SchedulesOSP();
                        ReportsOSP report = new ReportsOSP();

                        if (reader.IsDBNull(0) == false)
                            schedule.ID = reader.GetInt32(0);
                        else
                            schedule.ID = 0;

                        if (reader.IsDBNull(1) == false)
                            schedule.OSPs = reader.GetString(1).Split(',');
                        else
                            schedule.OSPs = new String[0];

                        schedule.OSPsOption = "ASLBG-GASLINI".Split('-');
                        for (int i = 0; i < schedule.OSPsOption.Length; i++)
                        {
                            string selected = "";
                            for (int r = 0; r < schedule.OSPs.Length; r++)
                            {
                                if (schedule.OSPsOption[i] == schedule.OSPs[r])
                                    selected = "selected";
                            }
                            schedule.OSPsOption[i] = "<option " + selected + ">" + schedule.OSPsOption[i] + "</option>";
                        }

                        if (reader.IsDBNull(2) == false)
                            schedule.Report = reader.GetString(2);
                        else
                            schedule.Report = null;

                        if (reader.IsDBNull(3) == false)
                            schedule.StartDate = reader.GetDateTime(3);
                        else
                            schedule.StartDate = DateTime.MinValue;

                        if (reader.IsDBNull(4) == false)
                            schedule.RepeatEveryNumb = reader.GetInt32(4);
                        else
                            schedule.RepeatEveryNumb = 0;

                        if (reader.IsDBNull(5) == false)
                            schedule.RepeatEveryType = reader.GetString(5);
                        else
                            schedule.RepeatEveryType = null;

                        schedule.RepeatEveryTypeOption = "DAY(s)-WEEK(s)-MONTH(s)-YEAR(s)".Split('-');

                        for (int i = 0; i < schedule.RepeatEveryTypeOption.Length; i++)
                        {
                            string selected = "";
                            if (schedule.RepeatEveryTypeOption[i] == schedule.RepeatEveryType)
                                selected = "selected";
                            schedule.RepeatEveryTypeOption[i] = "<option " + selected + ">" + schedule.RepeatEveryTypeOption[i] + "</option>";
                        }


                        if (reader.IsDBNull(6) == false)
                            schedule.DayOfWeek = reader.GetString(6).Split(',');
                        else
                            schedule.DayOfWeek = new String[0];

                        schedule.DayOfWeekOption = "Mon-Tue-Wed-Thu-Fri-Sat-Sun".Split('-');

                        for (int i = 0; i < schedule.DayOfWeekOption.Length; i++)
                        {
                            string selected = "";
                            for (int r = 0; r < schedule.DayOfWeek.Length; r++)
                            {
                                if (schedule.DayOfWeekOption[i] == schedule.DayOfWeek[r])
                                    selected = "selected";
                            }
                            schedule.DayOfWeekOption[i] = "<option " + selected + ">" + schedule.DayOfWeekOption[i] + "</option>";
                        }


                        if (reader.IsDBNull(7) == false)
                            schedule.StoragePeriodNumb = reader.GetInt32(7);
                        else
                            schedule.StoragePeriodNumb = 0;

                        if (reader.IsDBNull(8) == false)
                            schedule.StoragePeriodType = reader.GetString(8);
                        else
                            schedule.StoragePeriodType = null;

                        schedule.StoragePeriodTypeOption = "DAY(s)-WEEK(s)-MONTH(s)-YEAR(s)".Split('-');

                        for (int i = 0; i < schedule.StoragePeriodTypeOption.Length; i++)
                        {
                            string selected = "";

                            if (schedule.StoragePeriodTypeOption[i] == schedule.StoragePeriodType)
                                selected = "selected";

                            schedule.StoragePeriodTypeOption[i] = "<option " + selected + ">" + schedule.StoragePeriodTypeOption[i] + "</option>";
                        }

                        if (reader.IsDBNull(14) == false)
                            schedule.GiornoMese = reader.GetInt32(14);
                        else
                            schedule.GiornoMese = 0;

                        if (reader.IsDBNull(15) == false)
                            schedule.GiornoAnno = reader.GetDateTime(15);
                        else
                            schedule.GiornoAnno = DateTime.MinValue;

                        reportManagerOSP.schedulesObj.ScheduleDetailsList.Add(schedule);
                    }
                    reader.Close();

                }
                catch (Exception e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            connection.Close();


            return View(reportManagerOSP);
        }

        public ActionResult DataExtracts()
        {
            return View();
        }

        /*
        [HttpGet]
        public async Task<ActionResult> UserQuestionnaireGenerator()
        {
            using (HttpClient client = new HttpClient())
            {
                Uri qUri = new Uri("http://192.9.206.106:8080/operandocpcu/cpcu/robbie/0/0/");
                //StringContent OperandoJson = new StringContent(new JsonHelper().SerializeJsonFollowingOperandoConventions(policy), Encoding.UTF8, "application/json");
                var result = await client.GetAsync(qUri);
                Response.StatusCode = (int)result.StatusCode;
                var content = await result.Content.ReadAsStringAsync();
                //QGetQuestionnaire qGet = JsonConvert.DeserializeObject<QGetQuestionnaire>(content);
                return View();
            }
        }
        public ActionResult UserQuestionnaireGenerator1()
        {
            return View();
        }
        */

        /* Method modified by IT Innovation Centre 2017 */
        private string GetUppServiceTicket(string serviceName)
        {
            var ticketGrantingTicket = Session["TGT"] as string;

            return _aapiClient.GetServiceTicket(ticketGrantingTicket, serviceName);
        }

        /* Method modified by IT Innovation Centre 2017 */
        public ActionResult UppManagementTool()
        {
            string ospId = "587f7eb56e157a10eece95d3"; // local for http://10.136.24.87:8080/pdb
            ospId = "YellowPages";
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];
            string stHeaderName = ConfigurationManager.AppSettings["stHeaderName"];
            string pdbUPPSId = ConfigurationManager.AppSettings["pdbUPPSId"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));
            configuration.AddDefaultHeader(stHeaderName, GetUppServiceTicket(pdbUPPSId));

            var instance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            try
            {
                // UPP call to get the list of upp entries
                //var filter = "filter=\"%7B%27subscribed_osp_policies.osp_id%27:%27" + ospId + "%27%7D\"";
                var filter = "{\"subscribed_osp_policies.osp_id\":\"" + ospId + "\"}";
                List<UserPrivacyPolicy> response = instance.UserPrivacyPolicyGet(filter);

                /* response is a list of UserPrivacyPolicy we need to filter those for
                 * OSPConsents that match the ospId. we create a new list of OSPConsent type
                 * HOWEVER just for display purposes the ospId will contain the userId from UPP
                 */
                List<OSPConsents> modOspConsents = new List<OSPConsents>();
                Dictionary<string, UppTab2> uppStats = new Dictionary<string, UppTab2>();
                foreach(UserPrivacyPolicy upp in response)
                {
                    Debug.Print("upp found: " + upp.ToString());
                    OSPConsents ospConsents = new OSPConsents();                    
                    foreach(OSPConsents ospCons in upp.SubscribedOspPolicies)
                    {
                        if (ospCons.OspId == ospId)
                        {
                            // overwriting ospId with userId
                            ospConsents.OspId = upp.UserId;
                            ospConsents.AccessPolicies = ospCons.AccessPolicies;
                            modOspConsents.Add(ospConsents);
                            foreach(eu.operando.core.pdb.cli.Model.AccessPolicy ap in ospCons.AccessPolicies)
                            {
                                string key = ap.Subject + ap.Action + ap.Resource;
                                if (!uppStats.ContainsKey(key))
                                {
                                    UppTab2 tmpUpp = new UppTab2();
                                    tmpUpp.key = key;
                                    tmpUpp.action = ap.Action.ToString();
                                    tmpUpp.role = ap.Subject.ToString();
                                    tmpUpp.apType = ap.Resource.ToString();
                                    tmpUpp.stats = new List<bool>(new bool[] { (bool)ap.Permission });
                                    if(ap.Permission == true)
                                    {
                                        tmpUpp.yes = 1;
                                        tmpUpp.no = 0;
                                    }
                                    else
                                    {
                                        tmpUpp.yes = 0;
                                        tmpUpp.no = 1;
                                    }
                                    uppStats.Add(key, tmpUpp);
                                }
                                else
                                {
                                    uppStats[key].stats.Add((bool)ap.Permission);                                    
                                    if(ap.Permission == true)
                                    {
                                        uppStats[key].yes++;
                                    }
                                    else
                                    {
                                        uppStats[key].no++;
                                    }
                                }
                            }
                        }
                    }
                }

                Debug.Print("UPP response:" + response.ToString());

                ViewBag.modOspConsents = modOspConsents;
                ViewBag.uppStats = uppStats;

                return View();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserPrivacyPolicy GET: " + e.Message);
            }

            return View();
        }

        public async Task<ActionResult> BigDataAnalytics()
        {
            ICollection<Job> jobs = await _bdaClient.GetJobsAsync();

            var executions = jobs.Select(_ => new BdaJob(_)).ToList();

            return View(executions);
        }

        [HttpGet]
        public ActionResult RequestNewBdaExtract()
        {
            return View("RequestNewBdaExtraction");
    }

        [HttpPost]
        public async Task<ActionResult> RequestNewBdaExtract(RequestNewBdaExtractModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("RequestNewBdaExtraction", model);
            }

            try
            {
                var request = new ExtractionRequest
                {
                    RequesterName = model.RequesterName,
                    ContactEmail = model.ContactEmail,
                    RequestSummary = model.RequestSummary,
                    Osp = OspForCurrentUser,
                    RequestDate = DateTime.UtcNow
                };

                await _bdaClient.RequestNewBdaExtractionAsync(request);

                return RedirectToAction("BigDataAnalytics");
            }
            catch (Exception ex)
            {
                // TODO -- exception should be logged here
                return View("Error", new HandleErrorInfo(ex, "OspAdmin", "RequestNewBdaExtract"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddSchedule(BdaSchedule model)
        {
            var schedule = new Schedule
            {
                JobId = model.JobId,
                StartTime = model.StartTime,
                RepeatInterval = TimeSpan.FromDays(model.RepeatIntervalDays),
                OspScheduled = OspForCurrentUser
            };

            await _bdaClient.AddScheduleAsync(schedule);

            return RedirectToAction("BigDataAnalytics");
        }

        [HttpPost]
        public async Task<ActionResult> EditSchedule(BdaSchedule model)
        {
            var schedule = await _bdaClient.GetScheduleByIdAsync(model.Id);

            if (schedule == null || schedule.OspScheduled != OspForCurrentUser)
            {
                return new HttpUnauthorizedResult();
            }

            schedule.StartTime = model.StartTime;
            schedule.RepeatInterval = TimeSpan.FromDays(model.RepeatIntervalDays);

            await _bdaClient.UpdateScheduleAsync(schedule);

            return RedirectToAction("BigDataAnalytics");
        }

        public async Task<ActionResult> DeleteSchedule(string id)
        {
            var schedule = await _bdaClient.GetScheduleByIdAsync(id);

            if (schedule == null || schedule.OspScheduled != OspForCurrentUser)
            {
                return new HttpUnauthorizedResult();
            }

            await _bdaClient.DeleteScheduleAsync(schedule);

            return RedirectToAction("BigDataAnalytics");
        }

        /// <summary>
        /// TODO -- how to get the OSP the current user (an OSP admin) works for
        /// </summary>
        private string OspForCurrentUser { get; } = "OCC";
    }
}