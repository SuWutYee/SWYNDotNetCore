using DotNetCoreTraining.MvcApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace DotNetCoreTraining.MvcApp2.Controllers
{
    public class BlogRestClientController : Controller
    {
        private readonly RestClient _restClient;

        public BlogRestClientController(RestClient restClient)
        {
            _restClient = restClient;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)
        {
            BlogResponseModel model = new BlogResponseModel();

            RestRequest request = new RestRequest($"api/blog/{pageNo}/{pageSize}", Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;
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
            RestRequest request = new RestRequest("api/blog", Method.Post);
            request.AddJsonBody(model);
            await _restClient.ExecuteAsync(request);
            return Redirect("/Blog");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> EditBlog(int id)
        {
            BlogModel model = new BlogModel();
            RestRequest request = new RestRequest($"api/blog/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return Redirect("/Blog");
            }
            var json = response.Content;
            model = JsonConvert.DeserializeObject<BlogModel>(json)!;
            return View("EditBlog", model);
        }

        [ActionName("Update")]
        public async Task<IActionResult> UpdateBlog(int id,BlogModel model)
        {
            RestRequest request = new RestRequest($"api/blog/{id}", Method.Put);
            request.AddJsonBody(model);
            await _restClient.PutAsync(request);
            return Redirect("/Blog");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            RestRequest request = new RestRequest($"api/blog/{id}", Method.Delete);
            await _restClient.DeleteAsync(request);
            return Redirect("/Blog");
        }
    }
}
