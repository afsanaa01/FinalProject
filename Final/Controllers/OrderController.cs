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
    public class OrderController : Controller
    {
        private readonly AppDbContext db;

        public OrderController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            List<Sold> orders = db.Solds.Include(x => x.SoldItem).Where(x => x.SoldItem.AppUser.UserName == User.Identity.Name).ToList();
            return View(orders);
        }
    }
}
