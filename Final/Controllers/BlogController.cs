using Final.DAL;
using Final.Models;
using Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext db;

        public BlogController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel
            {
                galleries = db.Galleries.ToList(),
                blogs = db.Blogs.ToList(),
                blogComments = db.BlogComments.ToList(),
            };

            return View(hvm);
        }
        public IActionResult Idea(string comment, string name, string email)
        {
            BlogComment blogComment = new BlogComment();
            blogComment.Comment = comment;
            blogComment.Name = name;
            blogComment.Email = email;

            db.BlogComments.Add(blogComment);
            db.SaveChanges();

            return RedirectToAction("Index", "Blog");
        }
    }
}
