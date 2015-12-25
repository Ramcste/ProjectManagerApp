﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.XPath;

namespace ProjectManagerApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               
                namespaces: new string[] { "ProjectManagerApp.Controllers" }

            );

            //added for admin panel
            routes.MapRoute(
               name: "Default_Admin",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces:new string[]{ "ProjectManagerApp.Areas.Admin.Controllers" }
               
               );
        }
    }
}
