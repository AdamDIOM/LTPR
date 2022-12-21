using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LTPR.Models;

namespace LTPR.Data
{
    public class Admin : DbContext
    {
        public Admin (DbContextOptions<Admin> options)
            : base(options)
        {
        }

		public DbSet<LTPR.Models.tblIngredientInItem> tblIngredientInItem { get; set; } = default!;
		public DbSet<LTPR.Models.tblIngredients> tblIngredients { get; set; } = default!;
		public DbSet<LTPR.Models.tblItemOnMenu> tblItemOnMenu { get; set; } = default!;
		public DbSet<LTPR.Models.tblMenuAtRestaurant> tblMenuAtRestaurant { get; set; } = default!;
		public DbSet<LTPR.Models.tblMenuItem> tblMenuItem { get; set; } = default!;
		public DbSet<LTPR.Models.tblMenus> tblMenus { get; set; } = default!;
		public DbSet<LTPR.Models.tblRestaurants> tblRestaurants { get; set; } = default!;

	}
}
