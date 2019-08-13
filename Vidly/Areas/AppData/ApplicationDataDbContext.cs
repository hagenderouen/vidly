using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Areas.AppData
{
    public class ApplicationDataDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Vidly.db");
        }
    }
}
