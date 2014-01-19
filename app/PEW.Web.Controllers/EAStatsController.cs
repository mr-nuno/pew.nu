using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PEW.Core.Domain;
using PEW.Core.Interfaces.ApplicationServices;
using PEW.Web.Controllers.Filters;
using PEW.Web.Controllers.Models;

namespace PEW.Web.Controllers
{
	public class EAStatsController : BaseController
	{
		private readonly IEAStatisticsService _eaStatsService;

		public EAStatsController(IEAStatisticsService eaStatsService)
		{
			_eaStatsService = eaStatsService;
		}

		#region For internal calls

		[ExceptionHandler(ReturnJson = true)]
		public JsonResult FetchEAData(string id, int? historyCount, string game)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			var count = historyCount ?? 10;
			var stats = _eaStatsService.FetchHockeyStats(id, game);
			return Json(new JsonDataItemResponse<NHLStatistics> { Data = stats }, JsonRequestBehavior.AllowGet);
		}

		[ExceptionHandler(ReturnJson = true)]
		public JsonResult CompareStats(string ids, int? count, string game)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			var idList = ids.Split(',');
			var c = count ?? 15;
			var statsList = idList.Select(id => _eaStatsService.FetchHockeyStats(id, game)).ToList();
			return Json(new JsonDataListResponse<NHLStatistics> { Data = statsList });
		}

		#endregion

		#region For external calls

		[ExceptionHandler(ReturnJson = true, Order = 1)]
		public string Compare(string ids, int? count, string game, string callback, string mode)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			var idList = ids.Split(',');
			var c = count ?? 15;
			var statsList = idList.Select(id => _eaStatsService.FetchHockeyStats(id, game)).ToList();

			switch (mode)
			{
				case "jsonp":
					return string.Format("{0}({1});", callback, new JavaScriptSerializer().Serialize(statsList));
				case "json":
					return string.Format("{0}", new JavaScriptSerializer().Serialize(statsList));
			}

			throw new ArgumentOutOfRangeException(string.Format("{0} is not a valid request mode.", mode));
		}

		[ExceptionHandler(ReturnJson = true, Order = 1)]
		public string Fetch(string id, int? count, string game, string callback, string mode)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			var c = count ?? 15;
			var stats = _eaStatsService.FetchHockeyStats(id, game);
			switch (mode)
			{
				case "jsonp":
					return string.Format("{0}({1});", callback, new JavaScriptSerializer().Serialize(stats));
				case "json":
					return string.Format("{0}", new JavaScriptSerializer().Serialize(stats));
			}

			throw new ArgumentOutOfRangeException(string.Format("{0} is not a valid request mode.", mode));
		}

		#endregion

	}
}
