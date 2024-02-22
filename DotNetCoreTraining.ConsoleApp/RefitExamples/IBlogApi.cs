using DotNetCoreTraining.ConsoleApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraining.ConsoleApp.RefitExamples
{
    public interface IBlogApi
    {
        [Get("/api/Blog")]
        Task<IEnumerable<BlogModel>> GetBlogs();

        [Get("/api/Blog/{id}")]
        Task<BlogModel> GetBlogById(int id);

        [Post("/api/Blog")]
        Task<string> CreateBlog(BlogModel blog);

        [Put("/api/Blog/{id}")]
        Task<string> UpdateBlog(int id, BlogModel blog);
    }
}
