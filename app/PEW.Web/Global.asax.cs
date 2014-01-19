using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.Unity;
using PEW.Repository;
using PEW.Web.Controllers;
using PEW.Core.Domain;
using PEW.Core.Interfaces.Data;
using PEW.Data;
using PEW.Web.Helpers;

namespace PEW.Web
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RouteRegistrar.RegisterRoutes(RouteTable.Routes);

			var container = new UnityContainer();

			container.RegisterType<IDataContext, TCTContext>(new ContainerControlledLifetimeManager());

			var controllerFactory = new UnityControllerFactory(container);
			ControllerBuilder.Current.SetControllerFactory(controllerFactory); 

		}
	}
}