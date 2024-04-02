using DotNetCoreTraining.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.MvcApp.Controllers
{
    public class ApexChartController : Controller
    {
        private readonly BlogDbContext _context;
        public ApexChartController(BlogDbContext context) { _context = context; }
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
            var lstChart = _context.Charts.ToList();
            return View(lstChart);
        }

        public IActionResult PyramidChart()
        {
            var lstPyramid = _context.Pyramids.ToList();
            return View(lstPyramid);
        }
    }
}
