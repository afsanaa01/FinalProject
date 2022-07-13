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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Products1
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Products.Include(p => p.Color).Include(p => p.Rating).Include(p => p.SubInfo);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Products1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Color)
                .Include(p => p.Rating)
                .Include(p => p.SubInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products1/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name");
            ViewData["RatingId"] = new SelectList(_context.Ratings, "Id", "Number");
            ViewData["SubInfoId"] = new SelectList(_context.SubInfos, "Id", "Name");
            return View();
        }

        // POST: Admin/Products1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name");
            ViewData["RatingId"] = new SelectList(_context.Ratings, "Id", "Number");
            ViewData["SubInfoId"] = new SelectList(_context.SubInfos, "Id", "Name");
            if (!ModelState.IsValid) return View();
            Product duplicate = await _context.Products.FirstOrDefaultAsync(x => x.Name == product.Name);
            if (duplicate != null)
            {
                ModelState.AddModelError("Name", "Name must be unique.");
                return View();
            }

            if (!product.ImageFile.IsImage())
            {
                ModelState.AddModelError("ImageFile", "File can be only images.");
                return View();
            }

            if (!product.ImageFile.IsValidSize(500))
            {
                ModelState.AddModelError("ImageFile", "File can be max 500kb.");
                return View();
            }

            product.Image = await product.ImageFile.Upload(_env.WebRootPath, @"admin\assets\img");
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            if (product.ImageList != null && product.ImageList.Length > 0)
            {
                foreach (IFormFile item in product.ImageList)
                {
                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("ImageList", item.FileName + "file is not image.");
                        _context.Products.Remove(_context.Products.Find(product.Id));
                        await _context.SaveChangesAsync();
                        return View();
                    }

                    if (!item.IsValidSize(500))
                    {
                        ModelState.AddModelError("ImageList", item.FileName + "file is too big.");
                        _context.Products.Remove(_context.Products.Find(product.Id));
                        await _context.SaveChangesAsync();
                        return View();
                    }

                    ProductImage pi = new ProductImage();
                    pi.Img = await item.Upload(_env.WebRootPath, @"admin\assets\img");
                    pi.ProductId = product.Id;

                    await _context.ProductImages.AddAsync(pi);
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Products");
        }

        // GET: Admin/Products1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", product.ColorId);
            ViewData["RatingId"] = new SelectList(_context.Ratings, "Id", "Number", product.RatingId);
            ViewData["SubInfoId"] = new SelectList(_context.SubInfos, "Id", "Name", product.SubInfoId);
            return View(product);
        }

        // POST: Admin/Products1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", product.ColorId);
            ViewData["RatingId"] = new SelectList(_context.Ratings, "Id", "Number", product.RatingId);
            ViewData["SubInfoId"] = new SelectList(_context.SubInfos, "Id", "Name", product.SubInfoId);
            if (product.Image != null)
            {
                if (!(product.ImageFile.IsImage()))
                {
                    ModelState.AddModelError("Img", "File must be image.");
                }
                if (!(product.ImageFile.IsValidSize(500)))
                {
                    ModelState.AddModelError("Img", "File can be max 500 kb.");

                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"admin\assets\img", product.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                product.Image = await product.ImageFile.Upload(_env.WebRootPath, @"admin\assets\img");
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Products");
        }

        // GET: Admin/Products1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Color)
                .Include(p => p.Rating)
                .Include(p => p.SubInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
