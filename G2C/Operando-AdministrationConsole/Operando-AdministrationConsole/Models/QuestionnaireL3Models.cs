using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    public class L3Statement
    {
        public string statementString { get; set; }
        public int actionRank { get; set; }
        public string role { get; set; }
        public int roleRank { get; set; }
        public string action { get; set; }
        public string Metadata { get; set; }
        public int rating { get; set; }
        public int privacyRanking { get; set; }
        public double weight { get; set; }
    }

    public class L3Category
    {
        public List<L3Statement> statements { get; set; }
        public string title { get; set; }
    }

    public class L3Questionnaire
    {
        public string metadata { get; set; }
        public List<L3Category> category { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string serviceID { get; set; }
    }

    public class L3QResponse
    {
        public string error { get; set; }
        public string session { get; set; }
        public L3Questionnaire questionnaire { get; set; }
    }

    public class L3QRootObject
    {
        public L3QResponse response { get; set; }
    }
}