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
    public class SeasonFinestsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SeasonFinestsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/SeasonFinests
        public async Task<IActionResult> Index()
        {
            return View(await _context.SeasonFinests.ToListAsync());
        }

        // GET: Admin/SeasonFinests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasonFinest = await _context.SeasonFinests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seasonFinest == null)
            {
                return NotFound();
            }

            return View(seasonFinest);
        }

        // GET: Admin/SeasonFinests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SeasonFinests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Image,Name,Price,Img,Id")] SeasonFinest seasonFinest)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!(seasonFinest.Img.IsImage()))
            {
                ModelState.AddModelError("Img", "File must be image.");
            }
            if (!(seasonFinest.Img.IsValidSize(500)))
            {
                ModelState.AddModelError("Img", "File can be max 500 kb.");
                return View();
            }

            seasonFinest.Image = await seasonFinest.Img.Upload(_env.WebRootPath, @"admin\assets\img");

            await _context.SeasonFinests.AddAsync(seasonFinest);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "SeasonFinests");
        }

        // GET: Admin/SeasonFinests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasonFinest = await _context.SeasonFinests.FindAsync(id);
            if (seasonFinest == null)
            {
                return NotFound();
            }
            return View(seasonFinest);
        }

        // POST: Admin/SeasonFinests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Image,Name,Price,Img,Id")] SeasonFinest seasonFinest)
        {
            if (seasonFinest.Img != null)
            {
                if (!(seasonFinest.Img.IsImage()))
                {
                    ModelState.AddModelError("Img", "File must be image.");
                }
                if (!(seasonFinest.Img.IsValidSize(500)))
                {
                    ModelState.AddModelError("Img", "File can be max 500 kb.");
                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"admin\assets\img", seasonFinest.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                seasonFinest.Image = await seasonFinest.Img.Upload(_env.WebRootPath, @"admin\assets\img");
            }

            _context.SeasonFinests.Update(seasonFinest);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "SeasonFinests");
        }

        // GET: Admin/SeasonFinests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasonFinest = await _context.SeasonFinests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seasonFinest == null)
            {
                return NotFound();
            }

            return View(seasonFinest);
        }

        // POST: Admin/SeasonFinests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seasonFinest = await _context.SeasonFinests.FindAsync(id);
            _context.SeasonFinests.Remove(seasonFinest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeasonFinestExists(int id)
        {
            return _context.SeasonFinests.Any(e => e.Id == id);
        }
    }
}
