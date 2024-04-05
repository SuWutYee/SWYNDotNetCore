using DotNetCoreTraining.MvcApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace DotNetCoreTraining.MvcApp2.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogApi _blogApi;

        public BlogController(IBlogApi blogApi)
        {
            _blogApi = blogApi;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)
        {
            var model = await _blogApi.GetBlogs(pageNo, pageSize);
            return View("BlogIndex", model);
        }

        [ActionName("Create")]
        public IActionResult CreateBlog()
        {
            return View("CreateBlog");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> SaveBlog(BlogModel model)
        {
            await _blogApi.CreateBlog(model);
            return Redirect("/Blog");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> EditBlog(int id)
        {
            var model = await _blogApi.GetBlogById(id);
            return View("EditBlog", model);
        }

        [ActionName("Update")]
        public async Task<IActionResult> UpdateBlog(int id, BlogModel model)
        {
            await _blogApi.UpdateBlog(id, model);
            return Redirect("/Blog");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _blogApi.DeleteBlog(id);
            return Redirect("/Blog");
        }
    }
}
