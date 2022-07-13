using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Blog:BaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Date { get; set; }
        public string Part1 { get; set; }
        public string Name1 { get; set; }
        public string Part2 { get; set; }
        public string Name2 { get; set; }
        public string Part3 { get; set; }
        public string Name3 { get; set; }
        public string Part4 { get; set; }
        public string Name4 { get; set; }
        public string Part5 { get; set; }
        public string InnerImage { get; set; }
        public string Name5 { get; set; }
        public string Part6 { get; set; }
        public string Quote { get; set; }
        public string Part7 { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }
        [NotMapped]
        public IFormFile InnerImg { get; set; }
    }
}
