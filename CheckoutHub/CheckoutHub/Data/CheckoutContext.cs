using CheckoutHub.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckoutHub.Data
{
        public class CheckoutContext : DbContext
        {
            public CheckoutContext(DbContextOptions<CheckoutContext> options) : base(options)
            {
            }

            public DbSet<DrinkStock> DrinkStock { get; set; }
           

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<DrinkStock>().ToTable("DrinkStock");
                
            }
    }
    }
