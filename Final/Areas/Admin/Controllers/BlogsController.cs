using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final.DAL;
using Final.Models;
using Microsoft.AspNetCore.Hosting;
using Final.Utils;
using System.IO;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Blogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blogs.ToListAsync());
        }

        // GET: Admin/Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Image,Title,Subtitle,Date,Part1,Name1,Part2,Name2,Part3,Name3,Part4,Name4,Part5,InnerImage,Name5,Part6,Quote,Part7,Img,InnerImg,Id")] Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!(blog.Img.IsImage()) & !(blog.InnerImg.IsImage()))
            {
                ModelState.AddModelError("Img", "File must be image.");
            }
            if (!(blog.Img.IsValidSize(500)) & !(blog.InnerImg.IsValidSize(500)))
            {
                ModelState.AddModelError("Img", "File can be max 500 kb.");
                return View();
            }
            if (!(blog.InnerImg.IsImage()))
            {
                ModelState.AddModelError("Img", "File must be image.");
            }
            if (!(blog.InnerImg.IsValidSize(500)))
            {
                ModelState.AddModelError("Img", "File can be max 500 kb.");
                return View();
            }

            blog.Image = await blog.Img.Upload(_env.WebRootPath, @"admin\assets\img");
            blog.InnerImage = await blog.InnerImg.Upload(_env.WebRootPath, @"admin\assets\img");

            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Blogs");
        }

        // GET: Admin/Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Image,Title,Subtitle,Date,Part1,Name1,Part2,Name2,Part3,Name3,Part4,Name4,Part5,InnerImage,Name5,Part6,Quote,Part7,Img,Id")] Blog blog)
        {
            if (blog.Img != null)
            {
                if (!(blog.Img.IsImage()) & !(blog.InnerImg.IsImage()))
                {
                    ModelState.AddModelError("Img", "File must be image.");
                }
                if (!(blog.Img.IsValidSize(500)) & !(blog.InnerImg.IsValidSize(500)))
                {
                    ModelState.AddModelError("Img", "File can be max 500 kb.");
                    return View();
                }
                if (!(blog.InnerImg.IsImage()))
                {
                    ModelState.AddModelError("Img", "File must be image.");
                }
                if (!(blog.InnerImg.IsValidSize(500)))
                {
                    ModelState.AddModelError("Img", "File can be max 500 kb.");
                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"admin\assets\img", blog.Image);
                string filePath1 = Path.Combine(_env.WebRootPath, @"admin\assets\img", blog.InnerImage);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                if (System.IO.File.Exists(filePath1))
                {
                    System.IO.File.Delete(filePath1);
                }

                blog.Image = await blog.Img.Upload(_env.WebRootPath, @"admin\assets\img");
                blog.InnerImage = await blog.InnerImg.Upload(_env.WebRootPath, @"admin\assets\img");
            }

            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Blogs");
        }

        // GET: Admin/Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}
