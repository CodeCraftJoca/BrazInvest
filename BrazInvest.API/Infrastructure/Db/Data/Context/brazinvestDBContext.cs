using Infrastructure.Db.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infrastructure.Db.Data.Context
{
    public class BrazInvestDbContext : DbContext
    {

       
        public BrazInvestDbContext(DbContextOptions<BrazInvestDbContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Investment> Investments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship configuration (example: a user can have several investments)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Investments)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);
        }
    }
}
