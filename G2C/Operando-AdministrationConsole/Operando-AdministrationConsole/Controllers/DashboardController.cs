﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Operando_AdministrationConsole.Models;
using SharpConnect.MySql;
using SharpConnect.MySql.SyncPatt;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using eu.operando.core.bda;
using eu.operando.core.ldb;
using eu.operando.core.ldb.Model;
using eu.operando.core.pdb.cli.Model;
using Operando_AdministrationConsole.Helper;
using Operando_AdministrationConsole.Models.DashboardModels;
using Operando_AdministrationConsole.Models.DashboardModels.WidgetModels;
using Operando_AdministrationConsole.Models.DataSubjectModels;

namespace Operando_AdministrationConsole.Controllers
{
    public class DashboardController : Controller
    {
        ReportManager reportManager = new ReportManager();
        private readonly IBdaClient _bdaClient;
        private readonly ILdbClient _ldbService;

        /// <summary>
        /// TODO -- how to get the OSP the current user (an OSP admin) works for
        /// </summary>
        private string OspForCurrentUser { get; } = "OCC";

        public DashboardController()
        {
            _bdaClient = new BdaClient();
            _ldbService = new LdbClient(ConfigurationManager.AppSettings["ldbBasePath"]);
        }

        public ActionResult EmptyPage()
        {
            return View();
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            var userTypeStr = Session["Usertype"] as string;
            UserType userType;
            switch (userTypeStr)
            {
                case "osp_admin":
                    userType = UserType.OspAdmin;
                    break;
                case "privacy_analyst":
                    userType = UserType.PrivacyAnalyst;
                    break;
                case "normal_user":
                default:
                    userType = UserType.StandardUser;
                    break;
            }

            var model = new DashboardModel()
            {
                UserType = userType
            };

            if (userType == UserType.OspAdmin)
            {
                String _mysqlDBError =
                    "Can not connect to MySql Report DB, please change MySQLConnection inside web.config";

                // creo gli oggetti per popolare la pagina
                model.Results = new Results();
                model.Requests = new Requests();

                MySqlConnection connection =
                    new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);

                MySqlCommand cmd = null;

                // creo la lista dei result
                model.Results.ResultList = new List<Results>();

                try
                {

                    connection.Open();
                    String sql = "select * from T_report_mng_results ORDER BY ExecutionDate DESC Limit 0,3";
                    cmd = new MySqlCommand(sql, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            Results results = new Results();

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
                            {
                                results.FileName = reader.GetString(6);
                                results.FileName = "../reportSavePath/" + results.FileName;
                            }
                            else
                                results.FileName = null;

                            model.Results.ResultList.Add(results);
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
                    //throw e;
                    Results results = new Results();
                    results.ID = 0;
                    results.ExecutionDate = DateTime.Now;
                    results.FileName = "#";
                    results.Report = "Error";
                    results.ReportDescription = _mysqlDBError;
                    results.ReportVersion = "";
                    model.Results.ResultList.Add(results);
                }
                connection.Close();


                // creo la lista dei result
                model.Requests.RequestList = new List<Requests>();

                try
                {

                    connection.Open();

                    String sql = "select * from t_report_mng_request ORDER BY InsertDate DESC Limit 0,2";
                    cmd = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            Requests request = new Requests();

                            if (reader.IsDBNull(0) == false)
                                request.ID = reader.GetInt32(0);
                            else
                                request.ID = 0;

                            if (reader.IsDBNull(1) == false)
                                request.InsertDate = reader.GetDateTime(1);
                            else
                                request.InsertDate = DateTime.MinValue;

                            if (reader.IsDBNull(2) == false)
                                request.Name = reader.GetString(2);
                            else
                                request.Name = null;

                            if (reader.IsDBNull(3) == false)
                                request.Email = reader.GetString(3);
                            else
                                request.Email = null;

                            if (reader.IsDBNull(4) == false)
                                request.Description = reader.GetString(4);
                            else
                                request.Description = null;

                            model.Requests.RequestList.Add(request);
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
                    //throw e;
                    Requests request = new Requests();
                    request.ID = 0;
                    request.Description = _mysqlDBError;
                    request.Email = "#";
                    request.InsertDate = DateTime.Now;
                    request.Name = "#";
                    model.Requests.RequestList.Add(request);
                }
                connection.Close();
            }

            //return View();
            return View(model);
        }

        public ActionResult Notifications()
        {
            var username = Session["Username"] as string;

            IList<DataAccessLog> logMessages;

            try
            {
                logMessages = _ldbService.GetNotifications(username);
            }
            catch (Exception e)
            {
                Debug.Print("Dashboard could not get notifications: " + e.Message);
                logMessages = new List<DataAccessLog>()
                {
                    new DataAccessLog()
                    {
                        title = "Error",
                        description = "Could not get notifications",
                        logDate = DateTime.Now
                    }
                };
            }

            var model = logMessages.Select(_ => new NotificationsModel(_, Url))
                .OrderByDescending(_ => _.TimeStamp)
                .ToList();

            return View(model);
        }

        public ActionResult UserProfile()
        {
            return View();
        }

        #region Widgets

        [HttpGet]
        public PartialViewResult NotificationsWidget(int count = 5)
        {
            var username = Session["Username"] as string;

            IList<DataAccessLog> logMessages;

            try
            {
                logMessages = _ldbService.GetNotifications(username);
            }
            catch (Exception e)
            {
                Debug.Print("Dashboard could not get notifications: " + e.Message);
                logMessages = new List<DataAccessLog>()
                {
                    new DataAccessLog()
                    {
                        description = "Error - Could not get notifications",
                        logDate = DateTime.Now
                    }
                };
            }

            var model = logMessages.Select(_ => new NotificationsWidgetModel(_))
                .OrderByDescending(_ => _.TimeStamp)
                .Take(count).ToList();

            return PartialView("Widgets/_Notifications", model);
        }

        [HttpGet]
        public PartialViewResult DataRequestsWidget(int count = 5)
        {
            var username = Session["Username"] as string;

            IList<DataAccessLog> logMessages;

            try
            {
                logMessages = _ldbService.GetDataAccessLogs(username);
            }
            catch (Exception e)
            {
                Debug.Print("Dashboard could not get data access logs: " + e.Message);
                logMessages = new List<DataAccessLog>()
                {
                    new DataAccessLog()
                    {
                        description = "Error - Could not get data access logs",
                        logDate = DateTime.Now
                    }
                };
            }

            var groupedByOsp = logMessages
                .Where(l => l.arrayRequestedFields.Any())
                .GroupBy(l => l.ospId);





            var model = groupedByOsp.SelectMany(es =>
            {
                var accessPolicies = GetAccessPoliciesForOsp(es.Key);
                var resourceCache = new ResourceFriendlyNameCache(accessPolicies);
                var stringConverter = new ResourceCachingNiceStringConverter(resourceCache);
                return es.Select(e => new DataAccessLogModel(e, stringConverter));
            });

            var aggregator = new DataAccessLogAggregator();

            model = aggregator.Aggregate(model);

            return PartialView("Widgets/_DataRequests", model);
        }

        [HttpGet]
        public async Task<PartialViewResult> DataExtractRequestsWidget()
        {
            var requests = await _bdaClient.GetUnfulfilledBdaExtractionRequestsAsync();

            var model = requests.Select(_ => new DataExtractRequestModel(_));

            return PartialView("Widgets/_DataExtractRequests", model);
        }

        [HttpGet]
        public async Task<PartialViewResult> DataExtractsWidget(int count = 3)
        {
            var executions = await _bdaClient.GetLatestExecutionsForOspAsync(OspForCurrentUser, count);

            Task<DataExtractsModel>[] modelTasks = executions.Select(async _ =>
                {
                    var job = await _bdaClient.GetJobByIdAsync(_.JobId);

                    return new DataExtractsModel(_)
                    {
                        JobName = job?.JobName
                    };
                })
                .ToArray();

            var model = await Task.WhenAll(modelTasks);

            return PartialView("Widgets/_DataExtracts", model);
        }

        #endregion Widgets

        private IList<AccessPolicy> GetAccessPoliciesForOsp(string ospId)
        {
            string pdbBasePath = ConfigurationManager.AppSettings["pdbBasePath"];

            var configuration = new eu.operando.core.pdb.cli.Client.Configuration(new eu.operando.core.pdb.cli.Client.ApiClient(pdbBasePath));

            var instance = new eu.operando.core.pdb.cli.Api.GETApi(configuration);

            List<OSPPrivacyPolicy> ospPrivacyPolicies = new List<OSPPrivacyPolicy>();
            try
            {
                // OSP call to get the list of service providers
                var filter = "{\"policy_url\" : \""+ ospId + "\"}";
                var response = instance.OSPGet(filter);

                ospPrivacyPolicies.AddRange(response);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OSP list: " + e.Message);
            }
            return ospPrivacyPolicies.SelectMany(o => o.Policies).ToList();
        }
    }

}
