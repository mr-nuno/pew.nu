using System.Web;
using System.Web.Mvc;

namespace PEW.Web.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionFilter());
        }
    }

    public class ExceptionFilter : IExceptionFilter 
    {

        public void OnException(ExceptionContext filterContext)
        {
            var a = "";   
        }
    }
}