using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    public class Statement
    {
        public string statementString { get; set; }
        public string metadata { get; set; }
        public int rating { get; set; }
        public int privacyRanking { get; set; }
        public double weight { get; set; }
    }

    public class Category
    {
        public List<Statement> statements { get; set; }
        public string title { get; set; }
    }

    public class Questionnaire
    {
        public string metadata { get; set; }
        public List<Category> category { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string serviceID { get; set; }
    }

    public class QResponse
    {
        public string error { get; set; }
        public string session { get; set; }
        public Questionnaire questionnaire { get; set; }
    }

    public class QRootObject
    {
        public QResponse response { get; set; }
    }
}