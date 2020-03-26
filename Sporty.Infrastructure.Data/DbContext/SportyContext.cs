using Microsoft.EntityFrameworkCore;
using Sporty.Domain.Entities;
using Sporty.Infrastructure.Data.Extensions;
using System;

namespace Sporty.Infrastructure.Data
{
    public class SportyContext:DbContext
    {
        public SportyContext(DbContextOptions<SportyContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            builder.Entity<Order>().HasMany(o => o.Products);
            builder.Entity<Order>().HasOne(o => o.User);
            builder.Entity<User>().HasMany(o => o.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId);

            builder.Seed();
        }
    }
}
