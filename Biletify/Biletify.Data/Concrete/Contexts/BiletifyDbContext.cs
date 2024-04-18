using Biletify.Data.Concrete.EfCore.Configs;
using Biletify.Data.Extensions;
using Biletify.Entity.Concrete;
using Biletify.Entity.Concrete.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Data.Concrete.EfCore.Contexts
{
    public class BiletifyDbContext : IdentityDbContext<User, Role, string>
    {
        public BiletifyDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCategoryConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
