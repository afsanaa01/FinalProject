using Final.DAL;
using Final.Models;
using Final.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<AppUser> users = _userManager.Users.ToList();
            List<AppUserViewModel> appuserVM = new List<AppUserViewModel>();
            foreach (AppUser user in users)
            {
                AppUserViewModel userVM = new AppUserViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    IsActive = user.IsActive,
                };
                appuserVM.Add(userVM);
            }
            return View(appuserVM);
        }

        #region Activation
        public async Task<IActionResult> Activation(string id)
        {
            if (id == null) return RedirectToAction("Index", "Error");
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return RedirectToAction("Index", "Error");
            user.IsActive = !user.IsActive;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
