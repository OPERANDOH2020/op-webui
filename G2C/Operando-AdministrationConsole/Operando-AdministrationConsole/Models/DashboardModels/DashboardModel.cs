using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operando_AdministrationConsole.Models.DashboardModels
{
    public class DashboardModel
    {
        public UserType UserType { get; set; }

        public Requests Requests { get; set; }

        public Results Results { get; set; }
    }

    public enum UserType
    {
        StandardUser,
        OspAdmin,
        PrivacyAnalyst,
    }
}