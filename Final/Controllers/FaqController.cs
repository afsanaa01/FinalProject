using Final.DAL;
using Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class FaqController : Controller
    {
        private readonly AppDbContext db;

        public FaqController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel
            {
                galleries = db.Galleries.ToList(),
                faqs = db.Faqs.ToList(),
            };

            return View(hvm);
        }
    }
}
