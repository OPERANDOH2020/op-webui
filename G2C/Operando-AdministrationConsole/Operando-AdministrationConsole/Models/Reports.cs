using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    public class Reports
    {
        public string Report { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Location { get; set; }
        public string Parameters { get; set; }
        public string OSPs { get; set; }
        public List<Reports> ReportList { get; set; }
    }
}