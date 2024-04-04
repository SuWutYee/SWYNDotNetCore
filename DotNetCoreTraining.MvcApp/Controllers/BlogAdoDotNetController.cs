using DotNetCoreTraining.MvcApp.Models;
using DotNetCoreTraining.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.MvcApp.Controllers
{
    public class BlogAdoDotNetController : Controller
    {
        private readonly AdoDotNetService _adoDotNetService;
        public BlogAdoDotNetController(AdoDotNetService adoDotNetService)
        {
            _adoDotNetService = adoDotNetService;
        }

        public IActionResult Index()
        {
            var lst = _adoDotNetService.Query<BlogModel>("select * From tbl_blog;");
            return View(lst);
        }
    }
}
