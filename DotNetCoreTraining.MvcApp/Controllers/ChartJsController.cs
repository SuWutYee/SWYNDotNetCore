using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.MvcApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult BarChart()
        {
            return View();
        }

        public IActionResult PolarAreaChart()
        {
            return View();
        }
    }
}
