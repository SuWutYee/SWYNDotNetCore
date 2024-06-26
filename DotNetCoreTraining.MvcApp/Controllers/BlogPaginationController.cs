﻿using DotNetCoreTraining.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraining.MvcApp.Controllers
{
    public class BlogPaginationController : Controller
    {
        private readonly BlogDbContext _context;

        public BlogPaginationController(BlogDbContext context) { _context = context; }

        [ActionName("Index")]
        public IActionResult BlogIndex(int PageNo = 1, int PageSize = 10)
        { 
            BlogResponseModel model = new BlogResponseModel();

            // Calculate Page Count
            int rowCount = _context.Blogs.Count();
            int pageCount = rowCount / PageSize;
            if (rowCount % PageSize > 0) pageCount++;

            // Page No Validation
            if (PageNo > pageCount) return BadRequest(new { Message = "Invalid Page No." });

            // Get Data By Page
            var lst = _context.Blogs.Skip((PageNo - 1) * PageSize).Take(PageSize).ToList();

            // Assign Values
            model.PageNo = PageNo;
            model.PageSize = PageSize;
            model.PageCount = pageCount;
            model.Blogs = lst;
            return View("BlogIndex", model);
        }
    }
}
