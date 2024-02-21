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
        Task<List<BlogModel>> GetBlogs();
    }
}
