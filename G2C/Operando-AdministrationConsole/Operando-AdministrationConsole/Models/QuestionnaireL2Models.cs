using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    public class L2Statement
    {

        public string statementString { get; set; }
        public string role { get; set; }
        public string Metadata { get; set; }
        public int rating { get; set; }
        public int privacyRanking { get; set; }
        public double weight { get; set; }
        public int roleRank { get; set; }
    }

    public class L2Category
    {
        public List<L2Statement> statements { get; set; }
        public string title { get; set; }
    }

    public class L2Questionnaire
    {
        public string metadata { get; set; }
        public List<L2Category> category { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string serviceID { get; set; }
    }

    public class L2QResponse
    {
        public string error { get; set; }
        public string session { get; set; }
        public L2Questionnaire questionnaire { get; set; }
    }

    public class L2QRootObject
    {
        public L2QResponse response { get; set; }
    }
}