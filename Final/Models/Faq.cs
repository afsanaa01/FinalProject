using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Faq:BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
    }
}
