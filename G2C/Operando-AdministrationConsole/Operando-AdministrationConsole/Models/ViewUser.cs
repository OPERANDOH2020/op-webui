using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models
{
    public class ViewUser
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string email { get; set; }
        public string userType { get; set; }
        [DefaultValue("name")]
        public string fullName { get; set; }
        [DefaultValue("address")]
        public string address { get; set; }
        [DefaultValue("city")]
        public string city { get; set; }
        [DefaultValue("country")]
        public string country { get; set; }
    }
}