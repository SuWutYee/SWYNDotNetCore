using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.MvcApp.Controllers
{
    public class HighChartController : Controller
    {
        public IActionResult DonutChart()
        {
            return View();
        }

        public IActionResult ColumnChart()
        {
            return View();
        }
    }
}
