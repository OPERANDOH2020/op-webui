using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{

    public class QPPreference
    {

        public string category { get; set; }
        public string role { get; set; }
        public string action { get; set; }
        public string preference { get; set; }
    }

    public class QPResponse
    {
        public string error { get; set; }
        public string session { get; set; }
        public List<QPPreference> preferences { get; set; }
    }

    public class QPRootObject
    {
        public QPResponse response { get; set; }
    }
}