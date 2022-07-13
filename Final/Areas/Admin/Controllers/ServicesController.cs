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
    public class ServicesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ServicesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Services
        public async Task<IActionResult> Index()
        {
            return View(await _context.Services.ToListAsync());
        }

        // GET: Admin/Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Admin/Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title1,Text1,ExpertTitle,ExpertText,Title2,Text2,Img1,Img2,Img3,Id")] Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!(service.Img1.IsImage()))
            {
                ModelState.AddModelError("Img", "File must be image.");
            }
            if (!(service.Img1.IsValidSize(500)))
            {
                ModelState.AddModelError("Img", "File can be max 500 kb.");
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!(service.Img2.IsImage()))
            {
                ModelState.AddModelError("Img", "File must be image.");
            }
            if (!(service.Img2.IsValidSize(500)))
            {
                ModelState.AddModelError("Img", "File can be max 500 kb.");
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!(service.Img3.IsImage()))
            {
                ModelState.AddModelError("Img", "File must be image.");
            }
            if (!(service.Img3.IsValidSize(500)))
            {
                ModelState.AddModelError("Img", "File can be max 500 kb.");
                return View();
            }
            service.Gallery1 = await service.Img1.Upload(_env.WebRootPath, @"admin\assets\img");
            service.Gallery2 = await service.Img2.Upload(_env.WebRootPath, @"admin\assets\img");
            service.Gallery3 = await service.Img3.Upload(_env.WebRootPath, @"admin\assets\img");

            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Services");
        }

        // GET: Admin/Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: Admin/Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title1,Text1,ExpertTitle,ExpertText,Title2,Text2,Img1,Img2,Img3,Id")] Service service)
        {
            if (service.Img1 != null)
            {
                if (!(service.Img1.IsImage()))
                {
                    ModelState.AddModelError("Img", "File must be image.");
                }
                if (!(service.Img1.IsValidSize(500)))
                {
                    ModelState.AddModelError("Img", "File can be max 500 kb.");
                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"admin\assets\img", service.Gallery1);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                service.Gallery1 = await service.Img1.Upload(_env.WebRootPath, @"admin\assets\img");
            }
            if (service.Img2 != null)
            {
                if (!(service.Img2.IsImage()))
                {
                    ModelState.AddModelError("Img", "File must be image.");
                }
                if (!(service.Img2.IsValidSize(500)))
                {
                    ModelState.AddModelError("Img", "File can be max 500 kb.");
                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"admin\assets\img", service.Gallery2);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                service.Gallery2 = await service.Img2.Upload(_env.WebRootPath, @"admin\assets\img");
            }
            if (service.Img3 != null)
            {
                if (!(service.Img3.IsImage()))
                {
                    ModelState.AddModelError("Img", "File must be image.");
                }
                if (!(service.Img3.IsValidSize(500)))
                {
                    ModelState.AddModelError("Img", "File can be max 500 kb.");
                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"admin\assets\img", service.Gallery3);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                service.Gallery3 = await service.Img3.Upload(_env.WebRootPath, @"admin\assets\img");
            }
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Services");
        }

        // GET: Admin/Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Admin/Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
