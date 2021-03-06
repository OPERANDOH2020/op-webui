﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Operando_AdministrationConsole
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
                defaults: new { controller = "Access" , action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EditAccessPolicy",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "OspAdmin", action = "EditAccessPolicy", id = UrlParameter.Optional }
            );
        }
    }
}
