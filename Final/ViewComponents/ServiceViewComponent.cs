using Final.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly AppDbContext db;

        public ServiceViewComponent(AppDbContext _db)
        {
            db = _db;
        }

        public IViewComponentResult Invoke()
        {
            return View(db.ServiceCategories.ToList());
        }
    }
}
