using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PEW.ApplicationServices;
using PEW.Data;
using PEW.Web.Api.App_Start;

namespace PEW.Web.Api
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e) 
        {

        }

        protected void Application_Start()
        {
            //if (HttpContext.Current.IsDebuggingEnabled) Database.SetInitializer(new PewDbInitializer());

            DependencyInjectionConfig.Initialize();

            AutoMapperConfig.Configure();
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CorsConfig.RegisterCors(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Include
            };
        }
    }
}