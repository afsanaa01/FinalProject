using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Service:BaseEntity
    {
        public string Title1 { get; set; }
        public string Text1 { get; set; }
        public string ExpertTitle { get; set; }
        public string ExpertText { get; set; }
        public string Title2 { get; set; }
        public string Text2 { get; set; }
        public string Gallery1 { get; set; }
        public string Gallery2 { get; set; }
        public string Gallery3 { get; set; }
        public int ServiceCategoryId { get; set; }
        [ForeignKey("ServiceCategoryId")]
        public ServiceCategory ServiceCategory { get; set; }
        [NotMapped]
        public IFormFile Img1 { get; set; }
        [NotMapped]
        public IFormFile Img2 { get; set; }
        [NotMapped]
        public IFormFile Img3 { get; set; }
    }
}
