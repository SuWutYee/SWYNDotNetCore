using DotNetCoreTraining.ConsoleApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraining.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        private readonly string _apiUrl = "https://localhost:7029";
        public async void Run()
        {
            await Read();
            await Read(100);
            //await Create();
            await Update(11);
            await Delete(12);
        }

        private async Task Read()
        {
            var blogApi = RestService.For<IBlogApi>(_apiUrl);
            var response = await blogApi.GetBlogs();
            if (response.Count() == 0)
                Console.WriteLine(response!);
            Console.WriteLine("......Blogs......");
            foreach (var blog in response)
            {
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
            }
        }

        private async Task Read(int id)
        {
            try
            {
                var blogApi = RestService.For<IBlogApi>(_apiUrl);
                var response = await blogApi.GetBlogById(id);
                if (response != null)
                {
                    Console.WriteLine("....... Get Blog By Id .......");
                    Console.WriteLine(response.BlogTitle);
                    Console.WriteLine(response.BlogAuthor);
                    Console.WriteLine(response.BlogContent);
                }
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task Create()
        {
            BlogModel blog = new BlogModel
            {
                BlogAuthor = "AAAA",
                BlogTitle = "BBB",
                BlogContent = "CCCCCCC"
            };
            var blogApi = RestService.For<IBlogApi>(_apiUrl);
            var response = await blogApi.CreateBlog(blog);
            Console.WriteLine(response!);
        }

        private async Task Update(int id)
        {
            BlogModel blog = new BlogModel
            {
                BlogAuthor = "Su Wut Yee",
                BlogTitle = "SWYN",
                BlogContent = "SWYN Test"
            };
            var blogApi = RestService.For<IBlogApi>(_apiUrl);
            var response = await blogApi.UpdateBlog(id, blog);
            Console.WriteLine(response!);
        }

        private async Task Delete(int id)
        {
            try
            {
                var blogApi = RestService.For<IBlogApi>(_apiUrl);
                var response = await blogApi.DeleteBlog(id);
                Console.WriteLine(response!);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
