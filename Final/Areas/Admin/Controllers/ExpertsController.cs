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
    public class ExpertsController : Controller
    {
        private readonly AppDbContext _context;

        public ExpertsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Experts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Experts.ToListAsync());
        }

        // GET: Admin/Experts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expert = await _context.Experts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expert == null)
            {
                return NotFound();
            }

            return View(expert);
        }

        // GET: Admin/Experts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Experts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Phone,Email,Subject,Message,Id")] Expert expert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expert);
        }

        // GET: Admin/Experts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expert = await _context.Experts.FindAsync(id);
            if (expert == null)
            {
                return NotFound();
            }
            return View(expert);
        }

        // POST: Admin/Experts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,Phone,Email,Subject,Message,Id")] Expert expert)
        {
            if (id != expert.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpertExists(expert.Id))
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
            return View(expert);
        }

        // GET: Admin/Experts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expert = await _context.Experts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expert == null)
            {
                return NotFound();
            }

            return View(expert);
        }

        // POST: Admin/Experts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expert = await _context.Experts.FindAsync(id);
            _context.Experts.Remove(expert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpertExists(int id)
        {
            return _context.Experts.Any(e => e.Id == id);
        }
    }
}
