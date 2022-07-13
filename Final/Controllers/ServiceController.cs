using Final.DAL;
using Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext db;

        public ServiceController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index(int? id)
        {
            return View(db.Services.Where(x => x.ServiceCategoryId == id).FirstOrDefault());
        }
    }
}
