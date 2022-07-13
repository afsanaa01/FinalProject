using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Product:BaseEntity
    {
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Color Color { get; set; }
        [Required]
        public int RatingId { get; set; }
        [ForeignKey("RatingId")]
        public Rating Rating { get; set; }
        public int SubInfoId { get; set; }
        [ForeignKey("SubInfoId")]
        public SubInfo SubInfo { get; set; }
        public IEnumerable<Basket> Baskets { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public IFormFile[] ImageList { get; set; }

    }
}
