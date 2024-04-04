using DotNetCoreTraining.MvcApp.Models;
using DotNetCoreTraining.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.MvcApp.Controllers
{
    public class BlogDapperController : Controller
    {
        private readonly DapperService _dapperService;

        public BlogDapperController(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        public IActionResult Index()
        {
            var lstBlog = _dapperService.Query<BlogModel>("select * From tbl_blog;");
            return View(lstBlog);
        }
    }
}
