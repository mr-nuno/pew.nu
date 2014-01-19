using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using PEW.Core.Interfaces.ApplicationServices;
using PEW.Web.Api.Push;
using SignalR;

namespace PEW.Web.Api
{
    public class WorkersConfig
    {
        public static void Initialize()
        {
            //var ctx = HttpContext.Current;
            //var t = new Task(() => 
            //{
            //    HttpContext.Current = ctx;
            //    var statsService = ServiceLocator.Current.GetInstance<IEAStatisticsService>();
            //    var context = GlobalHost.ConnectionManager.GetConnectionContext<PushConnection>();

            //    context.Connection.Broadcast("init");

            //    while (true)
            //    {
            //        Thread.Sleep(60000);

            //        try
            //        {
            //            var profilesPlayedGames = statsService.AnyPlayedNewGame();
            //            if (profilesPlayedGames.Count() > 0)
            //            {
            //                context.Connection.Broadcast(String.Join(",", profilesPlayedGames.ToArray()));
            //            }
            //            else
            //            {
            //                context.Connection.Broadcast(false);
            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            context.Connection.Broadcast(e.Message);
            //        }
            //    }
            //});
            //t.Start();
        }
    }
}