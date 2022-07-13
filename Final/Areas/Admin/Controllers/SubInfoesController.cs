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
    public class SubInfoesController : Controller
    {
        private readonly AppDbContext _context;

        public SubInfoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SubInfoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SubInfos.Include(s => s.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/SubInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subInfo = await _context.SubInfos
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subInfo == null)
            {
                return NotFound();
            }

            return View(subInfo);
        }

        // GET: Admin/SubInfoes/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/SubInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CategoryId,Id")] SubInfo subInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", subInfo.CategoryId);
            return View(subInfo);
        }

        // GET: Admin/SubInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subInfo = await _context.SubInfos.FindAsync(id);
            if (subInfo == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", subInfo.CategoryId);
            return View(subInfo);
        }

        // POST: Admin/SubInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,CategoryId,Id")] SubInfo subInfo)
        {
            if (id != subInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubInfoExists(subInfo.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", subInfo.CategoryId);
            return View(subInfo);
        }

        // GET: Admin/SubInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subInfo = await _context.SubInfos
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subInfo == null)
            {
                return NotFound();
            }

            return View(subInfo);
        }

        // POST: Admin/SubInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subInfo = await _context.SubInfos.FindAsync(id);
            _context.SubInfos.Remove(subInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubInfoExists(int id)
        {
            return _context.SubInfos.Any(e => e.Id == id);
        }
    }
}
