using Microsoft.EntityFrameworkCore;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Wind> Wind { get; set; }
        public DbSet<Humidity> Humidity { get; set; }
        public DbSet<Station> Station { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Wind>().HasKey(w => w.Id);
        }


    }
}
