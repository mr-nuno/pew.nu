using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace PEW.Web.Controllers
{
	public class RouteRegistrar
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{*allaspx}", new { allaspx = @".*\.aspx(/.*)?" });
			routes.IgnoreRoute("{*allcss}", new { allcss = @".*\.css(/.*)?" });
			routes.IgnoreRoute("{*alljs}", new { alljs = @".*\.js(/.*)?" });
			routes.IgnoreRoute("{*allpng}", new { allpng = @".*\.png(/.*)?" });
			routes.IgnoreRoute("{*allgif}", new { allgif = @".*\.gif(/.*)?" });
			routes.IgnoreRoute("{*alljpg}", new { alljpg = @".*\.jpg(/.*)?" });

			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

			//routes.CreateArea("Admin", "TCT.Web.Controllers.Admin",
			//       routes.MapRouteLowercase("DefaultAdmin",
			//       "Admin/{controller}/{action}/{id}",
			//       new { controller = "User", action = "Index", id = UrlParameter.Optional })
			//   );

			routes.MapRouteLowercase(null, "ea/{game}/ps3/stats/{id}", new { controller = "EAStats", action = "FetchEAData" });
			routes.MapRouteLowercase(null, "ea/{game}/ps3/stats/compare/{ids}/history/{count}", new { controller = "EAStats", action = "CompareStats" });
			routes.MapRouteLowercase(null, "jsonp/ea/{game}/ps3/stats/{id}", new { controller = "EAStats", action = "Fetch", mode = "jsonp" });
			routes.MapRouteLowercase(null, "jsonp/ea/{game}/ps3/stats/compare/{ids}", new { controller = "EAStats", action = "Compare", mode = "jsonp" });
			routes.MapRouteLowercase(null, "jsonp/ea/{game}/ps3/stats/compare/{ids}/history/{count}", new { controller = "EAStats", action = "Compare", mode = "jsonp" });

			routes.MapRouteLowercase(null, "json/ea/{game}/ps3/stats/{id}", new { controller = "EAStats", action = "Fetch", mode = "json" });
			routes.MapRouteLowercase(null, "json/ea/{game}/ps3/stats/compare/{ids}", new { controller = "EAStats", action = "Compare", mode = "json" });
			routes.MapRouteLowercase(null, "json/ea/{game}/ps3/stats/compare/{ids}/history/{count}", new { controller = "EAStats", action = "Compare", mode = "json" });

			routes.MapRouteLowercase(
				 "Default", // Route name
				 "{controller}/{action}/{id}", // URL with parameters
				 new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);
		}
	}

	#region Route extensions

	public static class AreaRouteHelper
	{
		public static void CreateArea(this RouteCollection routes, string areaName, string controllersNamespace, params Route[] routeEntries)
		{
			foreach (var route in routeEntries)
			{
				if (route.Constraints == null)
					route.Constraints = new RouteValueDictionary();

				if (route.Defaults == null)
					route.Defaults = new RouteValueDictionary();

				if (route.DataTokens == null)
					route.DataTokens = new RouteValueDictionary();

				route.Constraints.Add("area", areaName);
				route.Defaults.Add("area", areaName);

				object a;
				if (route.DataTokens.TryGetValue("namespaces", out a))
				{
					var b = ((string[])a);

					var list = new List<string> { controllersNamespace };
					list.AddRange(b);

					route.DataTokens.Remove("namespaces");
					route.DataTokens.Add("namespaces", list.ToArray());
				}
				else
				{
					route.DataTokens.Add("namespaces", new[] { controllersNamespace });
				}

				if (!routes.Contains(route)) // To support "new Route()" in addition to "routes.MapRoute()"
					routes.Add(route);
			}
		}
	}

	public class LowercaseRoute : Route
	{
		public LowercaseRoute(string url, IRouteHandler routeHandler)
			: base(url, routeHandler) { }
		public LowercaseRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
			: base(url, defaults, routeHandler) { }
		public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
			: base(url, defaults, constraints, routeHandler) { }
		public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
			: base(url, defaults, constraints, dataTokens, routeHandler) { }

		public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
		{
			VirtualPathData path = base.GetVirtualPath(requestContext, values);

			if (path != null)
				path.VirtualPath = path.VirtualPath.ToLowerInvariant();

			return path;
		}
	}

	public static class RouteCollectionExtensions
	{
		public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults)
		{
			return routes.MapRouteLowercase(name, url, defaults, null, "TCT.Web.Controllers");
		}

		public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, object constraints, string controllersNamespace)
		{
			if (routes == null)
				throw new ArgumentNullException("routes");

			if (url == null)
				throw new ArgumentNullException("url");


			var route = new LowercaseRoute(url, new MvcRouteHandler())
			{
				Defaults = new RouteValueDictionary(defaults),
				Constraints = new RouteValueDictionary(constraints),

			};

			if (route.DataTokens == null)
				route.DataTokens = new RouteValueDictionary();

			object a;
			if (route.DataTokens.TryGetValue("namespaces", out a))
			{
				var b = ((string[])a);

				var list = new List<string> { controllersNamespace };
				list.AddRange(b);

				route.DataTokens.Remove("namespaces");
				route.DataTokens.Add("namespaces", list.ToArray());
			}
			else
			{
				route.DataTokens.Add("namespaces", new[] { controllersNamespace });
			}

			if (!routes.Contains(route))
			{
				if (!string.IsNullOrEmpty(name)) routes.Add(name, route);
				else routes.Add(route);
			}

			return route;
		}
	}
	
	#endregion

}
