using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModels
{
    public class ProductViewModel
    {
        public List<Product> products { get; set; }
        public List<Category> categories { get; set; }
        public List<Color> colors { get; set; }
        public List<Rating> ratings { get; set; }
        public List<Wish> wishs { get; set; }
        public List<Sold> solds { get; set; }
        public List<SoldItem> soldItems { get; set; }
        public List<SubInfo> subInfos { get; set; }
        public List<Basket> baskets { get; set; }
        public List<Wish> wishes { get; set; }
        public List<ProductImage> productImages { get; set; }
    }
}
