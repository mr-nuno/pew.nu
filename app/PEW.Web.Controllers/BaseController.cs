using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using PEW.Core.Domain;
using PEW.Web.Controllers.Models;

namespace PEW.Web.Controllers
{
	public abstract class BaseController : Controller
	{
		protected readonly LogWriter logger = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();

		protected BaseViewData CreateBaseViewData()
		{
			return new BaseViewData { LoggedInUser = new User() };
		}

		public ActionResult Error()
		{
			return View(BaseViewData.Default);
		}

		public JsonResult JsonError()
		{
			return new JsonResult();
		}
	}
}
