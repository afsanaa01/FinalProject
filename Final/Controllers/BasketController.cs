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
    public class BasketController : Controller
    {
        private readonly AppDbContext db;
        private readonly UserManager<AppUser> usermanager;


        public BasketController(AppDbContext _db, UserManager<AppUser> _usermanager)
        {
            db = _db;
            usermanager = _usermanager;
        }
        public IActionResult Index()
        {
            return View(db.Baskets.ToList());
        }

        public async Task<IActionResult> Cart(int? Id, double price, string size, string store, string deliveryDate, string message, int number)
        {
            if (Id == null) return RedirectToAction("Index", "Error");

            Product product = await db.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (product == null) return RedirectToAction("Index", "Error");

            AppUser user = User.Identity.IsAuthenticated ? await usermanager.FindByNameAsync(User.Identity.Name) : null;
            List<BasketViewModel> productBaskets = new List<BasketViewModel>();
            string basket = HttpContext.Request.Cookies["Basket"];
            if (!User.Identity.IsAuthenticated)
            {
                #region Cookie
                if (basket == null)
                {
                    BasketViewModel basketVM = new BasketViewModel
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Price=product.Price,
                        Image = product.Image,
                        Size=size,
                        Store=store,
                        DeliveryDate = deliveryDate,
                        Message = message,
                        Number = number,
                    };

                    productBaskets.Add(basketVM);

                }
                else
                {
                    productBaskets = JsonConvert.DeserializeObject<List<BasketViewModel>>(basket);
                    BasketViewModel productBasket = productBaskets.FirstOrDefault(x => x.ProductId == (int)Id);
                    if (productBasket == null)
                    {
                        productBaskets.Add(new BasketViewModel
                        {
                            ProductId = product.Id,
                            Name = product.Name,
                            Price = product.Price,
                            Image = product.Image,
                            Size = size,
                            Store = store,
                            DeliveryDate = deliveryDate,
                            Message = message,
                            Number = number,
                        });
                    }
                }
                HttpContext.Response.Cookies.Append("Basket", JsonConvert.SerializeObject(productBaskets));
                #endregion
            }
            else
            {
                Basket memberBasketItem = db.Baskets.FirstOrDefault(x => x.AppUserId == user.Id && x.ProductId == product.Id);
                if (memberBasketItem == null)
                {
                    memberBasketItem = new Basket
                    {
                        AppUserId = user.Id,
                        ProductId = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Image = product.Image,
                        Size = size,
                        Store = store,
                        DeliveryDate = deliveryDate,
                        Message = message,
                        Number = number,
                    };
                    db.Baskets.Add(memberBasketItem);
                }
            }
            productBaskets = db.Baskets.Select(x =>
                  new BasketViewModel
                  {
                      ProductId = product.Id,
                      Name = product.Name,
                      Price = product.Price,
                      Image = product.Image,
                      Size = size,
                      Store = store,
                      DeliveryDate = deliveryDate,
                      Message = message,
                      Number = number,
                      Total = (decimal)price * number,
                  }).ToList();

            db.SaveChanges();

            return RedirectToAction(nameof(Index), "Category");
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null) return RedirectToAction("Index", "Error");
            List<BasketViewModel> productBaskets = new List<BasketViewModel>();

            AppUser user = User.Identity.IsAuthenticated ? await usermanager.FindByNameAsync(User.Identity.Name) : null;
            Basket memberBasketItem = db.Baskets.FirstOrDefault(x => x.ProductId == Id);
            db.Baskets.Remove(memberBasketItem);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
