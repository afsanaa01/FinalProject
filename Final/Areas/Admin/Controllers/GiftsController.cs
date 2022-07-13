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
    public class GiftsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public GiftsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Gifts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gifts.ToListAsync());
        }

        // GET: Admin/Gifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gift = await _context.Gifts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gift == null)
            {
                return NotFound();
            }

            return View(gift);
        }

        // GET: Admin/Gifts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Gifts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Image,Name,Price,Img,Id")] Gift gift)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!(gift.Img.IsImage()))
            {
                ModelState.AddModelError("Img", "File must be image.");
            }
            if (!(gift.Img.IsValidSize(500)))
            {
                ModelState.AddModelError("Img", "File can be max 500 kb.");
                return View();
            }

            gift.Image = await gift.Img.Upload(_env.WebRootPath, @"admin\assets\img");


            await _context.Gifts.AddAsync(gift);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Gifts");
        }

        // GET: Admin/Gifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gift = await _context.Gifts.FindAsync(id);
            if (gift == null)
            {
                return NotFound();
            }
            return View(gift);
        }

        // POST: Admin/Gifts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Image,Name,Price,Img,Id")] Gift gift)
        {
            if (gift.Img != null)
            {
                if (!(gift.Img.IsImage()))
                {
                    ModelState.AddModelError("Img", "File must be image.");
                }
                if (!(gift.Img.IsValidSize(500)))
                {
                    ModelState.AddModelError("Img", "File can be max 500 kb.");
                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"admin\assets\img", gift.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                gift.Image = await gift.Img.Upload(_env.WebRootPath, @"admin\assets\img");
            }

            _context.Gifts.Update(gift);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Gifts");
        }

        // GET: Admin/Gifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gift = await _context.Gifts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gift == null)
            {
                return NotFound();
            }

            return View(gift);
        }

        // POST: Admin/Gifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gift = await _context.Gifts.FindAsync(id);
            _context.Gifts.Remove(gift);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiftExists(int id)
        {
            return _context.Gifts.Any(e => e.Id == id);
        }
    }
}
