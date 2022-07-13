using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final.DAL;
using Final.Models;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SoldsController : Controller
    {
        private readonly AppDbContext _context;

        public SoldsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Solds
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Solds.Include(s => s.Product).Include(s => s.SoldItem);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Solds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sold = await _context.Solds
                .Include(s => s.Product)
                .Include(s => s.SoldItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sold == null)
            {
                return NotFound();
            }

            return View(sold);
        }

        // GET: Admin/Solds/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Image");
            ViewData["SoldItemId"] = new SelectList(_context.SoldItems, "Id", "Id");
            return View();
        }

        // POST: Admin/Solds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Image,Name,TotalPrice,Size,Store,DeliveryDate,Message,Number,Address,SoldItemId,Id")] Sold sold)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sold);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Image", sold.ProductId);
            ViewData["SoldItemId"] = new SelectList(_context.SoldItems, "Id", "Id", sold.SoldItemId);
            return View(sold);
        }

        // GET: Admin/Solds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sold = await _context.Solds.FindAsync(id);
            if (sold == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Image", sold.ProductId);
            ViewData["SoldItemId"] = new SelectList(_context.SoldItems, "Id", "Id", sold.SoldItemId);
            return View(sold);
        }

        // POST: Admin/Solds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Image,Name,TotalPrice,Size,Store,DeliveryDate,Message,Number,Address,SoldItemId,Id")] Sold sold)
        {
            if (id != sold.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sold);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoldExists(sold.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Image", sold.ProductId);
            ViewData["SoldItemId"] = new SelectList(_context.SoldItems, "Id", "Id", sold.SoldItemId);
            return View(sold);
        }

        // GET: Admin/Solds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sold = await _context.Solds
                .Include(s => s.Product)
                .Include(s => s.SoldItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sold == null)
            {
                return NotFound();
            }

            return View(sold);
        }

        // POST: Admin/Solds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sold = await _context.Solds.FindAsync(id);
            _context.Solds.Remove(sold);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoldExists(int id)
        {
            return _context.Solds.Any(e => e.Id == id);
        }
    }
}
