using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace WriteDataSetToXSD
{
    class Program
    {
        static void Main(string[] args)
        {


            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            MySqlDataAdapter dtadd = new MySqlDataAdapter();
            dtadd.SelectCommand =  new MySqlCommand();

            dtadd.SelectCommand.Connection = connection;

            DataSet mydt = new DataSet("operando_report");
            dtadd.SelectCommand.CommandText = "select * from t_report_mng_list ";
            dtadd.Fill(mydt, "t_report_mng_list");
            dtadd.SelectCommand.CommandText = "select * from T_report_mng_schedules ";
            dtadd.Fill(mydt, "T_report_mng_schedules");
            dtadd.SelectCommand.CommandText = "select * from T_report_mng_results ";
            dtadd.Fill(mydt, "T_report_mng_results");
             

            String nomeFileg = AppDomain.CurrentDomain.BaseDirectory + "\\Schema_XSD_Report_MNG_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "" + DateTime.Now.Minute + ".xsd";
            mydt.WriteXmlSchema(nomeFileg);

            connection.ConnectionString = connection.ConnectionString.Replace("database=operando_report", "database=operando_data");
            dtadd.SelectCommand.Connection = connection;
            mydt = new DataSet("operando_data");
            dtadd.SelectCommand.CommandText = "select * from t_data_aslbergamo_gambling_diseases ";
            dtadd.Fill(mydt, "t_data_aslbergamo_gambling_diseases");
            dtadd.SelectCommand.CommandText = "select * from t_data_aslbergamo_gambling_pathology ";
            dtadd.Fill(mydt, "t_data_aslbergamo_gambling_pathology");
            dtadd.SelectCommand.CommandText = "select * from t_data_aslbergamo_gambling_patient ";
            dtadd.Fill(mydt, "t_data_aslbergamo_gambling_patient");

            nomeFileg = AppDomain.CurrentDomain.BaseDirectory + "\\Schema_XSD_Report_DATA_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "" + DateTime.Now.Minute + ".xsd";
            mydt.WriteXmlSchema(nomeFileg);

        }
    }
}
