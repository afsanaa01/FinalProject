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
    public class CategoryController : Controller
    {
        private readonly AppDbContext db;

        public CategoryController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            ViewBag.Count = db.Products.Count();
            return View(db.Products.Take(6).ToList());
        }

        public IActionResult Filter(string orderBy)
        {
            ViewBag.Count = db.Products.Count();
            switch (orderBy)
            {
                case "decrease":
                    return PartialView("_ProductsPartial", db.Products.OrderBy(p => p.Price).ToList());
                    break;
                case "increase":
                    return PartialView("_ProductsPartial", db.Products.OrderByDescending(p => p.Price).ToList());
                    break;
                case "letter":
                    return PartialView("_ProductsPartial", db.Products.OrderBy(p => p.Name).ToList());
                    break;
                default:
                    return PartialView("_ProductsPartial", db.Products.ToList());
                    break;
            }
        }

        public IActionResult LoadProductsAsView(int skip = 0)
        {
            return PartialView("_ProductsPartial", db.Products.Skip(skip).Take(6).ToList());
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchProduct(string query)
        {
            List<Product> result = db.Products.OrderBy(p => p.Price).Where(x => x.Name.ToLower().Contains(query.ToLower())).ToList();
            return PartialView("_ProductsPartial", result);
        }
    }
}
