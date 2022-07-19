using Final.DAL;
using Final.Models;
using Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext db;

        public ProductController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index(int? id)
        {
            ProductViewModel pvm = new ProductViewModel
            {
                ratings = db.Ratings.ToList(),
                colors = db.Colors.ToList(),
                subInfos = db.SubInfos.Where(x => x.CategoryId == id).ToList(),
                products = db.Products.Where(x => x.SubInfo.CategoryId == id).ToList(),
                categories = db.Categories.ToList(),
                productImages = db.ProductImages.ToList(),
            };
            return View(pvm);
        }

        public async Task<IActionResult> Select(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            Product product = await db.Products.Include(x => x.ProductImages).FirstOrDefaultAsync(x => x.Id == id);
            return View(product);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            Product product = await db.Products.Include(x => x.Color).Include(x => x.Rating).Include(x => x.ProductImages).FirstOrDefaultAsync(x => x.Id == id);
            return View(product);
        }

        public IActionResult LoadProductsAsView(int skip = 0)
        {
            return PartialView("_ProductsPartial", db.Products.Skip(skip).Take(6).ToList());
        }
    }
}
