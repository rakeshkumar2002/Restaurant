using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class Dish
    {
        public int DishId { get; set; }
        public string? DishName { get; set; }
        public string? DishDescription { get; set; }
        public decimal? DishPrice { get; set; }
        public string? DishImage { get; set; }
        public string? Nature { get; set; }
    }
}
