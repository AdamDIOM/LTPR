using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LTPR.Models;

namespace LTPR.Data
{
    public class LTPRContext : DbContext
    {
        public LTPRContext (DbContextOptions<LTPRContext> options)
            : base(options)
        {
        }

        public DbSet<tblImageOnMenuItem> tblImageOnMenuItem { get; set; }
        public DbSet<tblImages> tblImages { get; set; }
        public DbSet<tblIngredientInItem> tblIngredientInItem { get; set; }
        public DbSet<tblIngredients> tblIngredient { get; set; }
        public DbSet<tblItemOnMenu> tblItemOnMenu { get; set; }
        public DbSet<tblMenuAtRestaurant> tblMenuAtRestaurant { get; set; }
        public DbSet<tblMenuItem> tblMenuItem { get; set; }
        public DbSet<tblMenus> tblMenus { get; set; }
        public DbSet<tblRestaurants> tblRestaurants { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<tblImageOnMenuItem>().ToTable("tblImageOnMenuItem")
                .HasKey(e => new { e.IID, e.MIID })
                .HasName("PK_ImageOnMenuItem");
            modelbuilder.Entity<tblImages>().ToTable("tblImages");
            modelbuilder.Entity<tblIngredientInItem>().ToTable("tblIngredientInItem")
                .HasKey(e => new {e.IID, e.MIID})
                .HasName("PK_IngredientInItem");
            modelbuilder.Entity<tblIngredients>().ToTable("tblIngredients");
            modelbuilder.Entity<tblItemOnMenu>().ToTable("tblItemOnMenu")
                .HasKey(e => new {e.MID, e.IID })
                .HasName("PK_ItemOnMenu");
            modelbuilder.Entity<tblMenuAtRestaurant>().ToTable("tblMenuAtRestaurant")
                .HasKey(e => new {e.RID, e.MID})
                .HasName("PK_MenuAtRestaurant");
            modelbuilder.Entity<tblMenuItem>().ToTable("tblMenuItem");
            modelbuilder.Entity<tblMenus>().ToTable("tblMenus");
            modelbuilder.Entity<tblRestaurants>().ToTable("tblRestaurants");
        }
    }
}
