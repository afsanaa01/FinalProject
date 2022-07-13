using Final.DAL;
using Final.Models;
using Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class BlogItemController : Controller
    {
        private readonly AppDbContext db;

        public BlogItemController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index(int? id)
        {
            HomeViewModel pvm = new HomeViewModel
            {
                galleries = db.Galleries.ToList(),
                blogs = db.Blogs.ToList(),
                blogComments = db.BlogComments.ToList(),
            };
            if (id == null)
            {
                return View(pvm);
            }
            Blog blog = await db.Blogs.FirstOrDefaultAsync(x => x.Id == id);

            return View(blog);
        }
    }
}