using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModels
{
    public class AccountViewModel
    {
        public List<SeasonFinest> seasonFinests { get; set; }
        public List<Product> products { get; set; }
        public List<Category> categories { get; set; }
        public List<Color> colors { get; set; }
        public List<Rating> ratings { get; set; }
        public List<Wish> wishs { get; set; }
        public List<Sold> solds { get; set; }
        public List<SubInfo> subInfos { get; set; }
    }
}
