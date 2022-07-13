using Final.DAL;
using Final.Models;
using Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;

        public HomeController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel
            {
                galleries = db.Galleries.ToList(),
                populars = db.Populars.ToList(),
                seasonFinests = db.SeasonFinests.ToList(),
                blogs = db.Blogs.Take(3).ToList(),
                gifts = db.Gifts.ToList(),
                finestPlants = db.FinestPlants.ToList(),
            };

            return View(hvm);
        }

        public IActionResult Test(string name, string email, string phone, string message)
        {
            ContactUs contactUs = new ContactUs();
            contactUs.Name = name;
            contactUs.Email = email;
            contactUs.Phone = phone;
            contactUs.Message = message;

            db.ContactUs.Add(contactUs);
            db.SaveChanges();

            TempData["messageToUser"] = "Your message is sending...";
            return RedirectToAction("Index", "Contact");
        }
    }
}
