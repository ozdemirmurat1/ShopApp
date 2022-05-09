using Microsoft.EntityFrameworkCore;
using ShopApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp2.DataAccess.Concrete.EfCore
{
    public class ShopApp2Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = ShopApp2; Trusted_Connection = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(c => new { c.CategoryId, c.ProductId });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Cart> Carts { get; set; }
       

    }
}
