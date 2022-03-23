using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microservice2.Model;
using Microservice2.Ef.Configurations;


namespace Microservice2.Ef
{
    public class DebitCardDbContext : DbContext
    {
        public DbSet<DebitCard> DebitCard { get; set; }
        public DbSet<User> Users { get; set; }
        public DebitCardDbContext(DbContextOptions<DebitCardDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DebitCardConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=12345;Database=234");
        //}

    }
}

