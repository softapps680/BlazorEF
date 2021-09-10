using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorApp.Server.Entities;

#nullable disable

namespace BlazorApp.Server.Data
{
    public partial class BusinessContext : DbContext
    {
        public BusinessContext()
        {
        }

        public BusinessContext(DbContextOptions<BusinessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().ToTable("Products");


            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
            new { Id = 1, CategoryName = "Utrusning" },
            new { Id = 2, CategoryName = "Skötsel" },
            new { Id = 3, CategoryName = "Foder" });
            modelBuilder.Entity<Product>().HasData(
            new { Id = 1, Name = "Grimma", Description = "I nylonmaterial", ImageUrl = "https://www.hooks.se/pub_images/original/410247-2E_1.jpg?extend=copy&width=512&method=fit&height=512&type=webp&timestamp=1629121125", categoryId = 1 },
           new { Id = 2, Name = "Pälsglans", Description = "Perfekt resultat", ImageUrl = "https://www.hooks.se/pub_images/original/820057-00-00000_1.jpg?extend=copy&width=512&method=fit&height=512&type=webp&timestamp=1624291521", categoryId = 2 },
           new { Id = 3, Name = "Biotin", Description = "Tillskott", ImageUrl = "https://www.hooks.se/pub_images/original/820072-00-00000_1.jpg?extend=copy&width=512&method=fit&height=512&type=webp&timestamp=1617112200", categoryId = 3 });
     
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
