using Final.DAL;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewComponents
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly AppDbContext db;

        public BasketViewComponent(AppDbContext _db)
        {
            db = _db;
        }

        public IViewComponentResult Invoke()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Baskets.Where(x => x.AppUser.UserName == User.Identity.Name).ToList());
            }
            else
            {
                return View(new List<Basket>());
            }
        }
    }
}
