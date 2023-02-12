using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LTPR.Models;
using Microsoft.AspNetCore.Identity;

namespace LTPR.Data
{
    public class Admin : IdentityDbContext<ApplicationUser>
    {
        public Admin (DbContextOptions<Admin> options)
            : base(options)
        {
        }

        // declare all database tables
		public DbSet<LTPR.Models.tblIngredientInItem> tblIngredientInItem { get; set; } = default!;
		public DbSet<LTPR.Models.tblIngredients> tblIngredients { get; set; } = default!;
		public DbSet<LTPR.Models.tblItemOnMenu> tblItemOnMenu { get; set; } = default!;
		public DbSet<LTPR.Models.tblMenuAtRestaurant> tblMenuAtRestaurant { get; set; } = default!;
		public DbSet<LTPR.Models.tblMenuItem> tblMenuItem { get; set; } = default!;
		public DbSet<LTPR.Models.tblMenus> tblMenus { get; set; } = default!;
		public DbSet<LTPR.Models.tblRestaurants> tblRestaurants { get; set; } = default!;
		public DbSet<LTPR.Models.tblImages> tblImages { get; set; }
		public DbSet<LTPR.Models.tblImageOnMenuItem> tblImageOnMenuItem { get; set; }
        public DbSet<LTPR.Models.tblBasket> tblBasket { get; set; } = default!;
        public DbSet<LTPR.Models.tblSales> tblSales { get; set; } = default!;
        public DbSet<LTPR.Models.tblItemsOnSale> tblItemsOnSale { get; set; } = default!;
        public DbSet<LTPR.Models.tblDiscountCodes> tblDiscountCodes { get; set; }

     protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // init database tables
            modelbuilder.Entity<tblDiscountCodes>().ToTable("tblDiscountCodes");
            modelbuilder.Entity<tblItemsOnSale>().ToTable("tblItemsOnSale");
            modelbuilder.Entity<tblSales>().ToTable("tblSales");
            modelbuilder.Entity<tblBasket>().ToTable("tblBasket");
            modelbuilder.Entity<tblImageOnMenuItem>().ToTable("tblImageOnMenuItem");
            modelbuilder.Entity<tblImages>().ToTable("tblImages");
            modelbuilder.Entity<tblIngredientInItem>().ToTable("tblIngredientInItem");
            modelbuilder.Entity<tblIngredients>().ToTable("tblIngredients");
            modelbuilder.Entity<tblItemOnMenu>().ToTable("tblItemOnMenu");
            modelbuilder.Entity<tblMenuAtRestaurant>().ToTable("tblMenuAtRestaurant");
            modelbuilder.Entity<tblMenuItem>().ToTable("tblMenuItem");
            modelbuilder.Entity<tblMenus>().ToTable("tblMenus");
            modelbuilder.Entity<tblRestaurants>().ToTable("tblRestaurants");
            base.OnModelCreating(modelbuilder);
            modelbuilder.Ignore<IdentityUserLogin<string>>();
        }
    }
}
