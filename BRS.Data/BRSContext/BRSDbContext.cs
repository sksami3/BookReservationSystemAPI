using BRS.Core.Entity;
using BRS.Core.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Inventory.Data.InventoryContext
{
    public class BRSDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public BRSDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
            this.ChangeTracker.LazyLoadingEnabled = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("DefaultDatabase")).UseLazyLoadingProxies();
            options.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Histories)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.BookId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithOne(e => e.Author)
                .HasForeignKey(e => e.AuthorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Author>().HasQueryFilter(e => !e.IsDelete);
            modelBuilder.Entity<Book>().HasQueryFilter(e => !e.IsDelete);
        }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<ReservationHistory>? ReservationHistories { get; set; }
    }
}
