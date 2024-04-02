using DotNetCoreTraining.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogDbContext _context;

        public BlogController(BlogDbContext context)
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
            _context.SaveChanges();

            return Redirect("/Blog");
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                return Redirect("/Blog");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _context.SaveChanges();
            return Redirect("/Blog");
        }

        [ActionName("Delete")]
        public IActionResult DeleteBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if(item == null)
            {
                return Redirect("/Blog");
            }

            _context.Blogs.Remove(item);
            _context.SaveChanges();

            return Redirect("/Blog");
        }
    }
}
