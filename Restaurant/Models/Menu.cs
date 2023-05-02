using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class Menu
    {
        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public string? MenuDescription { get; set; }
        public string? MenuImage { get; set; }

        public virtual ICollection<MenuCategory> MenuCategories { get; set; }
    }
}
