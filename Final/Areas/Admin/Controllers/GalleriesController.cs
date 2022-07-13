using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final.DAL;
using Final.Models;
using Final.Utils;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleriesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public GalleriesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Galleries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Galleries.ToListAsync());
        }

        // GET: Admin/Galleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // GET: Admin/Galleries/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Image,Link,Id,Img")] Gallery gallery)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!(gallery.Img.IsImage()))
            {
                ModelState.AddModelError("Img", "File must be image.");
            }
            if (!(gallery.Img.IsValidSize(500)))
            {
                ModelState.AddModelError("Img", "File can be max 500 kb.");
                return View();
            }

            gallery.Image = await gallery.Img.Upload(_env.WebRootPath, @"admin\assets\img");

            await _context.Galleries.AddAsync(gallery);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Galleries");
        }

        // GET: Admin/Galleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            return View(gallery);
        }

        // POST: Admin/Galleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Image,Link,Img,Id")] Gallery gallery)
        {
            if (gallery.Img != null)
            {
                if (!(gallery.Img.IsImage()))
                {
                    ModelState.AddModelError("Img", "File must be image.");
                }
                if (!(gallery.Img.IsValidSize(500)))
                {
                    ModelState.AddModelError("Img", "File can be max 500 kb.");
                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"admin\assets\img", gallery.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                gallery.Image = await gallery.Img.Upload(_env.WebRootPath, @"admin\assets\img");
            }

            _context.Galleries.Update(gallery);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Galleries");
        }

        // GET: Admin/Galleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // POST: Admin/Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gallery = await _context.Galleries.FindAsync(id);
            _context.Galleries.Remove(gallery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryExists(int id)
        {
            return _context.Galleries.Any(e => e.Id == id);
        }
    }
}
