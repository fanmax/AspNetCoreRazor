using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRazor.Models;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRazor.ViewModels;

namespace AspNetCoreRazor.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasKey(x => x.Id);
        }

        public DbSet<AspNetCoreRazor.ViewModels.ClientViewModel> ClientViewModel { get; set; }
    }
}
