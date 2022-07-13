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
    public class SoldItemsController : Controller
    {
        private readonly AppDbContext _context;

        public SoldItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SoldItems
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SoldItems.Include(s => s.AppUser);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/SoldItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soldItem = await _context.SoldItems
                .Include(s => s.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soldItem == null)
            {
                return NotFound();
            }

            return View(soldItem);
        }

        // GET: Admin/SoldItems/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Admin/SoldItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppUserId,Id")] SoldItem soldItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soldItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "UserName", soldItem.AppUserId);
            return View(soldItem);
        }

        // GET: Admin/SoldItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soldItem = await _context.SoldItems.FindAsync(id);
            if (soldItem == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "UserName", soldItem.AppUserId);
            return View(soldItem);
        }

        // POST: Admin/SoldItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppUserId,Id")] SoldItem soldItem)
        {
            if (id != soldItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soldItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoldItemExists(soldItem.Id))
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
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "UserName", soldItem.AppUserId);
            return View(soldItem);
        }

        // GET: Admin/SoldItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soldItem = await _context.SoldItems
                .Include(s => s.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soldItem == null)
            {
                return NotFound();
            }

            return View(soldItem);
        }

        // POST: Admin/SoldItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soldItem = await _context.SoldItems.FindAsync(id);
            _context.SoldItems.Remove(soldItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoldItemExists(int id)
        {
            return _context.SoldItems.Any(e => e.Id == id);
        }
    }
}
