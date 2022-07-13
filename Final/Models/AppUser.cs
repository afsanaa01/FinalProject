using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<SoldItem> SoldItems { get; set; }
    }
}
