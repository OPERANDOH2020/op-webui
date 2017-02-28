using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Operando_AdministrationConsole.Models;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Threading.Tasks;
using eu.operando.core.bda;
using Operando_AdministrationConsole.Models.DashboardModels.WidgetModels;

namespace Operando_AdministrationConsole.Controllers
{
    public class DashboardController : Controller
    {
        ReportManager reportManager = new ReportManager();
        private readonly IBdaClient _bdaClient;

        /// <summary>
        /// TODO -- how to get the OSP the current user (an OSP admin) works for
        /// </summary>
        private string OspForCurrentUser { get; } = "OCC";

        public DashboardController()
        {
            _bdaClient = new BdaClient();
        }

        public ActionResult EmptyPage()
        {
            return View();
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            String _mysqlDBError = "Can not connect to MySql Report DB, please change MySQLConnection inside web.config";

            // creo gli oggetti per popolare la pagina
            reportManager.resultsObj = new Results();
            reportManager.requestsObj = new Requests();

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;


            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;


            // creo la lista dei result
            reportManager.resultsObj.ResultList = new List<Results>();

            try
            {

                connection.Open();

                cmd.CommandText = "select * from T_report_mng_results ORDER BY ExecutionDate DESC Limit 0,3";

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

                        reportManager.resultsObj.ResultList.Add(results);
                    }
                    reader.Close();

                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                }
            }
            catch (MySqlException e)
            {
                //throw e;
                Results results = new Results();
                results.ID = 0;
                results.ExecutionDate = DateTime.Now;
                results.FileName = "#";
                results.Report = "Error";
                results.ReportDescription = _mysqlDBError;
                results.ReportVersion = "";
                reportManager.resultsObj.ResultList.Add(results);
            }
            connection.Close();


            // creo la lista dei result
            reportManager.requestsObj.RequestList = new List<Requests>();

            try
            {

                connection.Open();

                cmd.CommandText = "select * from t_report_mng_request ORDER BY InsertDate DESC Limit 0,2";

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

                        reportManager.requestsObj.RequestList.Add(request);
                    }
                    reader.Close(); 
                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                }
            }
            catch (MySqlException e)
            {
                //throw e;
                Requests request = new Requests();
                request.ID = 0;
                request.Description = _mysqlDBError;
                request.Email = "#";
                request.InsertDate = DateTime.Now;
                request.Name = "#";
                reportManager.requestsObj.RequestList.Add(request);
            }
            connection.Close();


            //return View();
            return View(reportManager);
        }

        public ActionResult Notifications()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }

        #region Widgets

        [HttpGet]
        public PartialViewResult DataRequestsWidget(int count = 5)
        {
            var model = new List<DataRequestsModel>();

            return PartialView("Widgets/_DataRequests", model);
        }

        [HttpGet]
        public async Task<PartialViewResult> DataExtractRequestsWidget()
        {
            var requests = await _bdaClient.GetUnfulfilledBdaExtractionRequestsAsync();

            var model = requests.Select(_ => new DataExtractRequestModel
            {
                RequesterName = _.RequesterName,
                RequesterEmail = _.ContactEmail,
                RequestDetail = _.RequestSummary,
                RequesterOsp = _.Osp,
                RequestDate = _.RequestDate
            });

            return PartialView("Widgets/_DataExtractRequests", model);
        }

        [HttpGet]
        public async Task<PartialViewResult> DataExtractsWidget(int count = 3)
        {
            var executions = await _bdaClient.GetLatestExecutionsForOspAsync(OspForCurrentUser, count);

            Task<DataExtractsModel>[] modelTasks = executions.Select(async _ =>
            {
                var job = await _bdaClient.GetJobByIdAsync(_.JobId);

                return new DataExtractsModel
                {
                    ExtractionDate = _.ExecutionDate,
                    Version = _.VersionNumber,
                    DownloadUrl = _.DownloadLink,
                    JobName = job?.JobName
                };
            })
            .ToArray();

            var model = await Task.WhenAll(modelTasks);

            return PartialView("Widgets/_DataExtracts", model);
        }

        #endregion Widgets




        //// GET: Dashboard/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Dashboard/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Dashboard/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Dashboard/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Dashboard/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Dashboard/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Dashboard/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }


}
