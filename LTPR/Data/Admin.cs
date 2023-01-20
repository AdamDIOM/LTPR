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

		public DbSet<LTPR.Models.tblIngredientInItem> tblIngredientInItem { get; set; } = default!;
		public DbSet<LTPR.Models.tblIngredients> tblIngredients { get; set; } = default!;
		public DbSet<LTPR.Models.tblItemOnMenu> tblItemOnMenu { get; set; } = default!;
		public DbSet<LTPR.Models.tblMenuAtRestaurant> tblMenuAtRestaurant { get; set; } = default!;
		public DbSet<LTPR.Models.tblMenuItem> tblMenuItem { get; set; } = default!;
		public DbSet<LTPR.Models.tblMenus> tblMenus { get; set; } = default!;
		public DbSet<LTPR.Models.tblRestaurants> tblRestaurants { get; set; } = default!;
		public DbSet<LTPR.Models.tblImages> tblImages { get; set; }
		public DbSet<LTPR.Models.tblImageOnMenuItem> tblImageOnMenuItem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<tblImageOnMenuItem>().ToTable("tblImageOnMenuItem")
                .HasKey(e => new { e.IID, e.MIID })
                .HasName("PK_ImageOnMenuItem");
            modelbuilder.Entity<tblImages>().ToTable("tblImages");
            modelbuilder.Entity<tblIngredientInItem>().ToTable("tblIngredientInItem")
                .HasKey(e => new { e.IID, e.MIID })
                .HasName("PK_IngredientInItem");
            modelbuilder.Entity<tblIngredients>().ToTable("tblIngredients");
            modelbuilder.Entity<tblItemOnMenu>().ToTable("tblItemOnMenu")
                .HasKey(e => new { e.MID, e.IID })
                .HasName("PK_ItemOnMenu");
            modelbuilder.Entity<tblMenuAtRestaurant>().ToTable("tblMenuAtRestaurant")
                .HasKey(e => new { e.RID, e.MID })
                .HasName("PK_MenuAtRestaurant");
            modelbuilder.Entity<tblMenuItem>().ToTable("tblMenuItem");
            modelbuilder.Entity<tblMenus>().ToTable("tblMenus");
            modelbuilder.Entity<tblRestaurants>().ToTable("tblRestaurants");
            base.OnModelCreating(modelbuilder);
            modelbuilder.Ignore<IdentityUserLogin<string>>();
        }
    }
}
