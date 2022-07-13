using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Gift:BaseEntity
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }
    }
}
