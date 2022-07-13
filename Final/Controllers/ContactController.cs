using Final.DAL;
using Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext db;

        public ContactController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel
            {
                galleries = db.Galleries.ToList(),
                contactUs = db.ContactUs.ToList(),
            };

            return View(hvm);
        }
    }
}
