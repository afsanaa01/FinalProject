using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class ServiceCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<Service> Services { get; set; }
    }
}
