using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Sold:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Store { get; set; }
        public string DeliveryDate { get; set; }
        public string Message { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
        public int SoldItemId { get; set; }
        public SoldItem SoldItem { get; set; }
    }
}
