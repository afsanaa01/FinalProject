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
    public class FinestPlantsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FinestPlantsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/FinestPlants
        public async Task<IActionResult> Index()
        {
            return View(await _context.FinestPlants.ToListAsync());
        }

        // GET: Admin/FinestPlants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finestPlant = await _context.FinestPlants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finestPlant == null)
            {
                return NotFound();
            }

            return View(finestPlant);
        }

        // GET: Admin/FinestPlants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FinestPlants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Image,Name,Price,Img,Id")] FinestPlant finestPlant)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!(finestPlant.Img.IsImage()))
            {
                ModelState.AddModelError("Img", "File must be image.");
            }
            if (!(finestPlant.Img.IsValidSize(500)))
            {
                ModelState.AddModelError("Img", "File can be max 500 kb.");
                return View();
            }

            finestPlant.Image = await finestPlant.Img.Upload(_env.WebRootPath, @"admin\assets\img");

            await _context.FinestPlants.AddAsync(finestPlant);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "FinestPlants");
        }

        // GET: Admin/FinestPlants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finestPlant = await _context.FinestPlants.FindAsync(id);
            if (finestPlant == null)
            {
                return NotFound();
            }
            return View(finestPlant);
        }

        // POST: Admin/FinestPlants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Image,Name,Price,Img,Id")] FinestPlant finestPlant)
        {
            if (finestPlant.Img != null)
            {
                if (!(finestPlant.Img.IsImage()))
                {
                    ModelState.AddModelError("Img", "File must be image.");
                }
                if (!(finestPlant.Img.IsValidSize(500)))
                {
                    ModelState.AddModelError("Img", "File can be max 500 kb.");
                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"admin\assets\img", finestPlant.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                finestPlant.Image = await finestPlant.Img.Upload(_env.WebRootPath, @"admin\assets\img");
            }

            _context.FinestPlants.Update(finestPlant);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "FinestPlants");
        }

        // GET: Admin/FinestPlants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finestPlant = await _context.FinestPlants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finestPlant == null)
            {
                return NotFound();
            }

            return View(finestPlant);
        }

        // POST: Admin/FinestPlants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finestPlant = await _context.FinestPlants.FindAsync(id);
            _context.FinestPlants.Remove(finestPlant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinestPlantExists(int id)
        {
            return _context.FinestPlants.Any(e => e.Id == id);
        }
    }
}
