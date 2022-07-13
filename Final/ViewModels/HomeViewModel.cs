using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModels
{
    public class HomeViewModel
    {
        public List<Gallery> galleries { get; set; }
        public List<Popular> populars { get; set; }
        public List<SeasonFinest> seasonFinests { get; set; }
        public List<Blog> blogs { get; set; }
        public List<Gift> gifts { get; set; }
        public List<FinestPlant> finestPlants { get; set; }
        public List<Service> services { get; set; }
        public List<ContactUs> contactUs { get; set; }
        public List<Faq> faqs { get; set; }
        public List<Expert> experts { get; set; }
        public List<AppUser> appUsers { get; set; }
        public List<Product> products { get; set; }
        public List<Category> categories { get; set; }
        public List<Color> colors { get; set; }
        public List<Rating> ratings { get; set; }
        public List<Wish> wishs { get; set; }
        public List<Sold> solds { get; set; }
        public List<SubInfo> subInfos { get; set; }
        public List<Basket> baskets { get; set; }
        public List<Wish> wishes { get; set; }
        public List<ServiceCategory> serviceCategories { get; set; }
        public List<BlogComment> blogComments { get; set; }
    }
}
