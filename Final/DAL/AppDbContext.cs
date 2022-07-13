using Final.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Popular> Populars { get; set; }
        public DbSet<SeasonFinest> SeasonFinests { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<FinestPlant> FinestPlants { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Wish> Wishs { get; set; }
        public DbSet<Sold> Solds { get; set; }
        public DbSet<SoldItem> SoldItems { get; set; }
        public DbSet<SubInfo> SubInfos { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
    }
}
