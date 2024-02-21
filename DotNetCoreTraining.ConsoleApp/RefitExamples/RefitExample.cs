using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraining.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        private readonly string _apiUrl = "https://localhost:7029/api/Blog";
        public async void Run()
        {
            await Read();
            //await Read(2);
            //await Create();
            //await Update(2);
            //await Delete(2);
        }

        private async Task Read()
        {
            var blogApi = RestService.For<IBlogApi>(_apiUrl);
            var response = await blogApi.GetBlogs();
            Console.WriteLine(response!);
        }

        //private async Task Read(int id)
        //{
        //    HttpClient client = new HttpClient();
        //    var response = await client.GetAsync($"https://localhost:7029/api/Blog/{id}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseStr = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine(responseStr);
        //    }
        //}

        //private async Task Create()
        //{
        //    BlogModel blog = new BlogModel
        //    {
        //        BlogAuthor = "Tun Tun",
        //        BlogTitle = "TTT",
        //        BlogContent = "Description"
        //    };
        //    HttpClient client = new HttpClient();
        //    var response = await client.PostAsync("https://localhost:7029/api/Blog/", JsonContent.Create(blog));
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine("Create Successfully!!!");
        //    }
        //}

        //private async Task Update(int id)
        //{
        //    BlogModel blog = new BlogModel
        //    {
        //        BlogAuthor = "Su Wut Yee",
        //        BlogTitle = "SWYN",
        //        BlogContent = "SWYN Test"
        //    };
        //    HttpClient client = new HttpClient();
        //    var response = await client.PutAsync($"https://localhost:7029/api/Blog/{id}", JsonContent.Create(blog));
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine("Update Successfully!!!");
        //    }
        //}

        //private async Task Delete(int id)
        //{
        //    HttpClient client = new HttpClient();
        //    var response = await client.DeleteAsync($"https://localhost:7029/api/Blog/{id}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine("Delete Successfully!!!");
        //    }
        //}
    }
}
