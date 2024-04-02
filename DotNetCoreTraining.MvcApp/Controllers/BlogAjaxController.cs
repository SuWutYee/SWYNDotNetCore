using DotNetCoreTraining.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.MvcApp.Controllers
{
    public class BlogAjaxController : Controller
    {
        private readonly BlogDbContext _context;

        public BlogAjaxController(BlogDbContext context)
        {
            _context = context;
        }

        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            var lstBlog = _context.Blogs.ToList();
            return View("BlogIndex", lstBlog);
        }

        [ActionName("Edit")]
        public IActionResult EditBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                return Redirect("/Blog");
            }
            return View("EditBlog", item);
        }

        [ActionName("Create")]
        public IActionResult CreateBlog()
        {
            return View("CreateBlog");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult SaveBlog(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            int result = _context.SaveChanges();
            string message = result > 0 ? "Save Successful." : "Save Failed.";
            BlogMessageResponseModel model = new BlogMessageResponseModel
            {
                IsSuccess = result > 0,
                Message = message
            };
            return Json(model);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            BlogMessageResponseModel model = new BlogMessageResponseModel();
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                model = new BlogMessageResponseModel { IsSuccess = false, Message = "No data found." };
                return Json(model);
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            int result = _context.SaveChanges();
            var message = result > 0 ? "Update Successful." : "Update Failed.";

            model = new BlogMessageResponseModel { IsSuccess = result > 0, Message = message };
            return Json(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteBlog(BlogModel blog)
        {
            BlogMessageResponseModel model = new BlogMessageResponseModel();
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == blog.BlogId);
            if (item == null)
            {
                model = new BlogMessageResponseModel { IsSuccess = false, Message = "No data found." };
                return Json(model);
            }

            _context.Blogs.Remove(item);
            int result = _context.SaveChanges();
            var message = result > 0 ? "Delete Successful." : "Delete Failed.";

            model = new BlogMessageResponseModel { IsSuccess = result > 0, Message = message };
            return Json(model);
        }
    }
}
