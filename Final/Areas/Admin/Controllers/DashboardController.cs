using Final.Areas.Admin.Models;
using Final.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class DashboardController : Controller
    {
        private readonly AppDbContext db;

        public DashboardController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            DashboardViewModel dvm = new DashboardViewModel();
            dvm.CategoryCount = await db.Categories.CountAsync();
            dvm.ProductCount = await db.Products.CountAsync();
            dvm.UserCount = await db.Users.CountAsync();

            return View(dvm);
        }
    }
}
