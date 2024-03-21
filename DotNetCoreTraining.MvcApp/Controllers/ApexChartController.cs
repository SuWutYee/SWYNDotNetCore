using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.MvcApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult RadarChart()
        {
            return View();
        }
    }
}
