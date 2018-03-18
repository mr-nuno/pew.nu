using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PEW.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static string GetVersion()
        {
            try
            {
                var assembly = typeof(MvcApplication).Assembly;
                var name = assembly.GetName();
                return name.Version.ToString();
            }
            catch (Exception)
            {
                return "0.0.0.0";
            }
        }
    }
}
