using DotNetCoreTraining.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.MvcApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult RadarChart()
        {
            ApexChartResponseModel model = new ApexChartResponseModel
            {
                Data = new List<int> { 20, 100, 40, 30, 50, 80, 33 },
                Category = new List<string> { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" }
            };
            return View(model);
        }

        public IActionResult MixedLineColumnAreaChart()
        {
            BlogDbContext context = new BlogDbContext();
            var lstChart = context.Charts.ToList();
            return View(lstChart);
        }

        public IActionResult PyramidChart()
        {
            BlogDbContext context = new BlogDbContext();
            var lstPyramid = context.Pyramids.ToList();
            return View(lstPyramid);
        }
    }
}
