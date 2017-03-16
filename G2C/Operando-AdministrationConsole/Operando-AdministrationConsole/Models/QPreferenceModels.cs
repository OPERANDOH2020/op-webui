using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{

    public class Preference
    {
        public string Category { get; set; }
        public double Result { get; set; }
    }

    public class Response
    {
        public string error { get; set; }
        public string session { get; set; }
        public List<Preference> preferences { get; set; }
    }

    public class RootObject
    {
        public Response response { get; set; }
    }
}