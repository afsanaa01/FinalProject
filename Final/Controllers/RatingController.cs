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
    public class RatingController : Controller
    {
        private readonly AppDbContext db;

        public RatingController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index(int? id)
        {
            ProductViewModel pvm = new ProductViewModel
            {
                ratings = db.Ratings.ToList(),
                colors = db.Colors.ToList(),
                products = db.Products.Where(x => x.RatingId == id).ToList(),
                categories = db.Categories.ToList(),
            };
            if (id == null)
            {
                return View(pvm);
            }
            Rating rating = await db.Ratings.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);

            return View(rating);
        }
    }
}
