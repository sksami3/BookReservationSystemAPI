using BRS.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Data.InventoryContext
{
    public class BRSDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public BRSDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<ReservationHistory> ReservationHistories { get; set; }
    }
}
