using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Rating : BaseEntity
    {
        public string Number { get; set; }
        public List<Product> Products { get; set; }
    }
}
