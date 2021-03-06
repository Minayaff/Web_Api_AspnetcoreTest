﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Model
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
