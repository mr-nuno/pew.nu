using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using PEW.Web.Api.Push;
using SignalR;

namespace PEW.Web.Api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapConnection<PushConnection>("push", "push/{*operation}");

            routes.MapHttpRoute(
                name: "HockeyStatsApi",
                routeTemplate: "hockeystats/{league}",
                defaults: new { controller = "HockeyStats", action = "GetTotalPointsLeaderboard" }
            );

            routes.MapHttpRoute(
                name: "StatsApi",
                routeTemplate: "stats/{game}/{platform}/{gamerTag}",
                defaults: new { controller = "Stats", action = "GetStats" }
            );

            routes.MapHttpRoute(
                name: "MatchHistoryApi",
                routeTemplate: "history/{game}/{platform}/{gamerTag}",
                defaults: new { controller = "Stats", action = "GetHistory", count = UrlParameter.Optional }
            );

            routes.MapHttpRoute(
                name: "LeaderBoardApi",
                routeTemplate: "leaderboard/{game}/{platform}/{gamerTag}",
                defaults: new { controller = "Stats", action = "GetLeaderboard", count = UrlParameter.Optional }
            );

            routes.MapHttpRoute(
                name: "LevelApi",
                routeTemplate: "level/{game}/{platform}/{gamerTag}",
                defaults: new { controller = "Stats", action = "GetLevel", count = UrlParameter.Optional }
            );

            routes.MapHttpRoute(
                name: "ProfileApi",
                routeTemplate: "profile/{gamerTag}",
                defaults: new { controller = "Profile", gamerTag = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}