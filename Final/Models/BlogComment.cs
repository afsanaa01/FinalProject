using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class BlogComment:BaseEntity
    {
        public string Comment { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
