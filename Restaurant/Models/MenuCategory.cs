using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public partial class MenuCategory
    {
        [Key]
        public int MenuId { get; set; }
       [Key]
        public int CategoryId { get; set; }
        public int? DisplayOrder { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Menu? Menu { get; set; } = null!;
    }
}
