using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
    }
}
