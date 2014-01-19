using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PEW.Core.Domain;
using PEW.Core.Interfaces.Data;
using PEW.Repository;

namespace PEW.Web.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
