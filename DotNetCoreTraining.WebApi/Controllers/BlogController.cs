using DotNetCoreTraining.WebApi.EfCoreExamples;
using DotNetCoreTraining.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogDbContext _db;
        public BlogController()
        {
            _db = new BlogDbContext();
        }

        [HttpGet]
        public ActionResult GetBlogs()
        {
            List<BlogModel> lstBlog = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();
            return Ok(lstBlog);
        }

        [HttpGet("{PageNo}/{PageSize}")]
        public ActionResult GetBlogs(int PageNo,int PageSize)
        {
            BlogResponseModel model = new BlogResponseModel();

            // Calculate Page Count
            int rowCount = _db.Blogs.Count();
            int pageCount = rowCount / PageSize;
            if (rowCount % PageSize > 0) pageCount++;

            // Page No Validation
            if (PageNo > pageCount) return BadRequest(new { Message = "Invalid Page No." });

            // Get Data By Page
            var lst = _db.Blogs.Skip((PageNo -1) * PageSize).Take(PageSize).ToList();

            // Assign Values
            model.PageNo = PageNo;
            model.PageSize = PageSize;
            model.PageCount= pageCount;
            model.Blogs = lst;

            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult GetBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(x=>x.BlogId== id);
            if (item==null)
            {
                return NotFound("No Data Found!");
            }
            return Ok(item);
        }

        [HttpPost]
        public ActionResult CreateBlog(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Create Success." : "Create Fail.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBlog(int id , BlogModel blog)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                return NotFound("No data found!");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _db.SaveChanges();

            var message = result == 0 ? "Edit Fail!" : "Edit Success.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBlog(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                return NotFound("No data found!");
            }
            _db.Blogs.Remove(item);
            var result = _db.SaveChanges();

            var message = result == 0 ? "Delete Fail!" : "Delete Success.";
            return Ok(message);
        }
    }
}
