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
    public class ServiceItemController : Controller
    {
        private readonly AppDbContext db;

        public ServiceItemController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index(int? id)
        {
            HomeViewModel pvm = new HomeViewModel
            {
                galleries = db.Galleries.ToList(),
                services = db.Services.ToList(),
            };
            if (id == null)
            {
                return View(pvm);
            }
            Service service = await db.Services.FirstOrDefaultAsync(x => x.Id == id);

            return View(service);
        }
    }
}
