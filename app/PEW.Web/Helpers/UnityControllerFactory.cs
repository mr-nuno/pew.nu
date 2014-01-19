using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace PEW.Web.Helpers
{
	public class UnityControllerFactory : DefaultControllerFactory
	{
		private readonly IUnityContainer container;
		public UnityControllerFactory(IUnityContainer container)
		{
			this.container = container;
		}

		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
		{
			return container.Resolve(controllerType) as IController;
		}
	}
}