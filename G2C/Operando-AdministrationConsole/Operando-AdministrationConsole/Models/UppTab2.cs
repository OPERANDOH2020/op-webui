using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    // Auxiliary class to help UPP Management Tool pages
    public class UppTab2
    {
        public string key { get; set; }
        public string role { get; set; }
        public string action { get; set; }
        public string apType { get; set; }
        public List<bool> stats { get; set; }
        public int yes {get; set;}
        public int no { get; set; }

    }
}