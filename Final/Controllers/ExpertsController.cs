using Final.DAL;
using Final.Models;
using Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class ExpertsController : Controller
    {
        private readonly AppDbContext db;

        public ExpertsController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel
            {
                galleries = db.Galleries.ToList(),
                experts = db.Experts.ToList(),
            };

            return View(hvm);
        }
        public IActionResult Subject(string name, string surname, string phone, string email, string subject, string message)
        {
            Expert expert = new Expert();
            expert.Name = name;
            expert.Surname = surname;
            expert.Phone = phone;
            expert.Email = email;
            expert.Subject = subject;
            expert.Message = message;

            db.Experts.Add(expert);
            db.SaveChanges();

            TempData["messageToUser"] = "Your message is sending...";
            return RedirectToAction("Index", "Experts");
        }
    }
}
