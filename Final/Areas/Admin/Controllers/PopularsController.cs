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
    public class PopularsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PopularsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET: Admin/Populars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Populars.ToListAsync());
        }

        // GET: Admin/Populars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popular = await _context.Populars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (popular == null)
            {
                return NotFound();
            }

            return View(popular);
        }

        // GET: Admin/Populars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Populars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Image,Title,Img,Id")] Popular popular)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!(popular.Img.IsImage()))
            {
                ModelState.AddModelError("Img", "File must be image.");
            }
            if (!(popular.Img.IsValidSize(500)))
            {
                ModelState.AddModelError("Img", "File can be max 500 kb.");
                return View();
            }

            popular.Image = await popular.Img.Upload(_env.WebRootPath, @"admin\assets\img");

            await _context.Populars.AddAsync(popular);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Populars");
        }

        // GET: Admin/Populars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popular = await _context.Populars.FindAsync(id);
            if (popular == null)
            {
                return NotFound();
            }
            return View(popular);
        }

        // POST: Admin/Populars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Image,Title,Img,Id")] Popular popular)
        {
            if (popular.Img != null)
            {
                if (!(popular.Img.IsImage()))
                {
                    ModelState.AddModelError("Img", "File must be image.");
                }
                if (!(popular.Img.IsValidSize(500)))
                {
                    ModelState.AddModelError("Img", "File can be max 500 kb.");
                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"admin\assets\img", popular.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                popular.Image = await popular.Img.Upload(_env.WebRootPath, @"admin\assets\img");
            }

            _context.Populars.Update(popular);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Populars");
        }

        // GET: Admin/Populars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popular = await _context.Populars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (popular == null)
            {
                return NotFound();
            }

            return View(popular);
        }

        // POST: Admin/Populars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var popular = await _context.Populars.FindAsync(id);
            _context.Populars.Remove(popular);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PopularExists(int id)
        {
            return _context.Populars.Any(e => e.Id == id);
        }
    }
}
