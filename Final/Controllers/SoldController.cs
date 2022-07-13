using Final.DAL;
using Final.Models;
using Final.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class SoldController : Controller
    {
        private readonly AppDbContext db;
        private readonly UserManager<AppUser> userManager;
        private readonly IWebHostEnvironment env;

        public SoldController(AppDbContext _db, UserManager<AppUser> _userManager,
            IWebHostEnvironment _env)
        {
            db = _db;
            userManager = _userManager;
            env = _env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Ready(string address, int total)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Error");

            AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);

            List<Basket> basketItems = await db.Baskets
                .Include(x => x.Product)
                .Where(x => x.AppUserId == appUser.Id)
                .ToListAsync();

            if (basketItems.Count <= 0)
            {
                TempData["Error"] = true;
                return RedirectToAction("Index", "Home");
            }
            SoldItem order = new SoldItem
            {
                AppUserId = appUser.Id,
            };

            List<Sold> orderItems = new List<Sold>();

            foreach (Basket item in basketItems)
            {
                Sold orderItem = new Sold
                {
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Image = item.Image,
                    Size = item.Size,
                    Store = item.Store,
                    DeliveryDate = item.DeliveryDate,
                    Message = item.Message,
                    Number = item.Number,
                    Address = address,
                };
                orderItems.Add(orderItem);
            }

            order.Solds = orderItems;

            await db.SoldItems.AddAsync(order);
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Order");
        }
    }
}
