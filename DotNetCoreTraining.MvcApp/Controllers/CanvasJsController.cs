using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.MvcApp.Controllers
{
    public class CanvasJsController : Controller
    {
        public IActionResult DashedLineChart()
        {
            return View();
        }

        public IActionResult SplineAreaChart()
        {
            return View();
        }
    }
}
