using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DealerOrders.Models;

namespace DealerOrders.Repositories
{
    public class VehicleOrderDbContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<VehicleModel> VehicleModels { get; set; }

        public DbSet<VehicleOption> VehicleOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<VehicleModel>().ToTable("VehicleModel");
            modelBuilder.Entity<VehicleOption>().ToTable("VehicleOption");
            base.OnModelCreating(modelBuilder);
        }
    }
}