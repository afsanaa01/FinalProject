using Final.DAL;
using Final.Models;
using Final.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class WishlistController : Controller
    {
        private readonly AppDbContext db;
        private readonly UserManager<AppUser> usermanager;


        public WishlistController(AppDbContext _db, UserManager<AppUser> _usermanager)
        {
            db = _db;
            usermanager = _usermanager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Wishs.Where(x => x.AppUser.UserName == User.Identity.Name).ToList());
            }
            else
            {
                return View(new List<Wish>());
            }
        }

        public async Task<IActionResult> Cart(int? Id, double price, string size, string store, string deliveryDate, string message, int number)
        {
            if (Id == null) return RedirectToAction("Index", "Error");

            Product product = await db.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (product == null) return RedirectToAction("Index", "Error");

            AppUser user = User.Identity.IsAuthenticated ? await usermanager.FindByNameAsync(User.Identity.Name) : null;
            List<WishViewModel> productWishs = new List<WishViewModel>();
            string Wish = HttpContext.Request.Cookies["Wish"];
            if (!User.Identity.IsAuthenticated)
            {
                #region Cookie
                if (Wish == null)
                {
                    WishViewModel WishVM = new WishViewModel
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Image = product.Image,
                    };

                    productWishs.Add(WishVM);

                }
                else
                {
                    productWishs = JsonConvert.DeserializeObject<List<WishViewModel>>(Wish);
                    WishViewModel productWish = productWishs.FirstOrDefault(x => x.ProductId == (int)Id);
                    if (productWish == null)
                    {
                        productWishs.Add(new WishViewModel
                        {
                            ProductId = product.Id,
                            Name = product.Name,
                            Price = product.Price,
                            Image = product.Image,
                        });
                    }
                }
                HttpContext.Response.Cookies.Append("Wish", JsonConvert.SerializeObject(productWishs));
                #endregion
            }
            else
            {
                Wish memberWishItem = db.Wishs.FirstOrDefault(x => x.AppUserId == user.Id && x.ProductId == product.Id);
                if (memberWishItem == null)
                {
                    memberWishItem = new Wish
                    {
                        AppUserId = user.Id,
                        ProductId = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Image = product.Image,
                    };
                    db.Wishs.Add(memberWishItem);
                }
            }
            productWishs = db.Wishs.Select(x =>
                  new WishViewModel
                  {
                      ProductId = product.Id,
                      Name = product.Name,
                      Price = product.Price,
                      Image = product.Image,
                  }).ToList();

            db.SaveChanges();

            return RedirectToAction(nameof(Index), "Category");
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null) return RedirectToAction("Index", "Error");
            List<WishViewModel> productWishs = new List<WishViewModel>();

            AppUser user = User.Identity.IsAuthenticated ? await usermanager.FindByNameAsync(User.Identity.Name) : null;
            Wish memberWishItem = db.Wishs.FirstOrDefault(x => x.ProductId == Id);
            db.Wishs.Remove(memberWishItem);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
