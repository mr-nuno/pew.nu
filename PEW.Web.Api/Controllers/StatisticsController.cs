using Microsoft.AspNetCore.Mvc;

namespace PEW.Web.Api.Controllers
{
    [Produces("application/json")]
    public class StatisticsController : Controller
    {
        [Route("statistics/hockey")]
        public IActionResult GetHockeyStatistics()
        {
            return Ok();
        }
    }
}