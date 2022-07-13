using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Gallery:BaseEntity
    {
        public string Image { get; set; }
        public string Link { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }
    }
}
