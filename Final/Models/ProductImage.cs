using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class ProductImage:BaseEntity
    {
        public string Img { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
