using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PEW.Core.Domain;
using PEW.Core.Interfaces.Data;
using PEW.Web.Controllers.Models;
using PEW.Repository;

namespace PEW.Web.Controllers
{
	public class HomeController : BaseController
	{
		public HomeController()
		{

		}

		public ActionResult Index()
		{
			var vd = CreateBaseViewData();
			vd.CurrentSection = BaseViewData.Section.Home;
			vd.CurrentTab = BaseViewData.Tab.Home;
			return View(vd);
		}
	}
}
