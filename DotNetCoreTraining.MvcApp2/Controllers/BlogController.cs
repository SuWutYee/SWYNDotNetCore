using DotNetCoreTraining.MvcApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace DotNetCoreTraining.MvcApp2.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient;

        public BlogController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)
        {
            BlogResponseModel model = new BlogResponseModel();
            var response = await _httpClient.GetAsync($"api/blog/{pageNo}/{pageSize}");
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<BlogResponseModel>(jsonStr)!;
            }
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
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("api/blog", content);
            return Redirect("/Blog");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> EditBlog(int id)
        {
            BlogModel model = new BlogModel();
            var response = await _httpClient.GetAsync($"api/blog/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return Redirect("/Blog");
            }
            var json = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<BlogModel>(json)!;
            return View("EditBlog", model);
        }

        [ActionName("Update")]
        public async Task<IActionResult> UpdateBlog(int id,BlogModel model)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model),System.Text.Encoding.UTF8,"application/json");
            await _httpClient.PutAsync($"api/blog/{id}", content);
            return Redirect("/Blog");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _httpClient.DeleteAsync($"api/blog/{id}");
            return Redirect("/Blog");
        }
    }
}
