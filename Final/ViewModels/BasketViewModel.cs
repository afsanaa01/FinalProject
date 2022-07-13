using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModels
{
    public class BasketViewModel
    {
        public int ProductId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string Store { get; set; }
        public string DeliveryDate { get; set; }
        public string Message { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
    }
}
