using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Diagnostics;

namespace PEW.Web.Controllers.Filters
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
	public class ExceptionHandler : FilterAttribute, IExceptionFilter
	{
		public Type ExceptionType;
		public TraceEventType Severity = TraceEventType.Error;
		public string Category = "Error";
		public int Priority = -1;
		public int EventId = 0;
		public int HttpStatusCode = 0;
		public string View;
		public string RedirectToAction;
		public string RedirectToController;

		public bool ReturnJson { get; set; }

		const string defaultAction = "Error";
		private const string defaultJsonAction = "JsonError";

		public void OnException(ExceptionContext filterContext)
		{
			if (filterContext.ExceptionHandled)
				return;

			if (ExceptionType != null && !filterContext.Exception.GetType().Equals(ExceptionType)) return;
			
			if (Logger.IsLoggingEnabled())
			{
				var logEntry = new LogEntry { Severity = Severity };

				if (!String.IsNullOrEmpty(Category))
					logEntry.Categories.Add(Category);

				if (EventId > 0)
					logEntry.EventId = EventId;

				if (Priority >= 0)
					logEntry.Priority = Priority;

				logEntry.Title = filterContext.Exception.Message;
				logEntry.Message = filterContext.Exception.ToString();

				Logger.Write(logEntry);
			}

			if (ReturnJson)
			{
				filterContext.ExceptionHandled = true;
				filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new {action = defaultJsonAction }));
			}
			else
			{
				filterContext.ExceptionHandled = true;
				filterContext.Result = string.IsNullOrEmpty(RedirectToAction) ?
					new RedirectToRouteResult(new RouteValueDictionary(new { action = defaultAction })) :
					new RedirectToRouteResult(new RouteValueDictionary(new { action = RedirectToAction }));
			}
		}
	}
}