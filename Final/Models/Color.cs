﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
