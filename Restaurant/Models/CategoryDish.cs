using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public partial class CategoryDish
    {
        [Key]
        public int CategoryId { get; set; }
        [Key]
        public int DishId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Dish Dish { get; set; } = null!;
    }
}
