using Microsoft.EntityFrameworkCore;
using EFMultipleTables.Models;
using System.Collections.Generic;

namespace EFMultipleTables.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}