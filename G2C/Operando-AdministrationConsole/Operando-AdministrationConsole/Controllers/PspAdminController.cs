using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Operando_AdministrationConsole.Models;

namespace Operando_AdministrationConsole.Controllers
{
    public class PspAdminController : Controller
    {
        Reports reports = new Reports();

        // GET: PspAdmin
        public ActionResult ReportsConfig()
        {
            MySqlConnection connection = new MySqlConnection();

            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            reports.ReportList = new List<Operando_AdministrationConsole.Models.Reports>();

            try
            {

                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText ="select * from t_report_mng_list ";

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Reports report = new Reports();

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
                            report.OSPs = reader.GetString(5);
                        else
                            report.OSPs = null;

                        reports.ReportList.Add(report);
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
                throw e;
            }
            connection.Close();

            return View(reports);
        }

    }

}