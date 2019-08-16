
using Ecommerce.ShippingExito.Tracking.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Ecommerce.ShippingExito.Tracking.Infrastructure.Data.Context
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
   
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{env}.json", optional: true)
                                .Build();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarrierService>().HasMany(g => g.Shipments)
                                               .WithOne(so => so.CarrierService).IsRequired();

            modelBuilder.Entity<Carrier>().HasMany(g => g.CarrierServices)
                                              .WithOne(so => so.Carrier).IsRequired();

            //modelBuilder.Entity<Shipment>().HasMany(g => g.ShipmentEvents)
            //                               .WithOne(so => so.Shipment).IsRequired();                                          


            //modelBuilder.Entity<ShipmentEvent>().HasOne(g => g.Shipment)
            //                                 .WithMany(so => so.ShipmentEvents).IsRequired()
            //                                 .HasForeignKey(q => q.ShipmentId);

            modelBuilder.Entity<Shipment>().HasMany(g => g.ShipmentEvents)
                                      .WithOne(so => so.Shipment).IsRequired();


        }

        public DbSet<Carrier> carrier { get; set; }
        public DbSet<Shipment> shipment { get; set; }
        public DbSet<CarrierService> carrierService { get; set; }
        public DbSet<ShipmentEvent> shipmenEvent { get; set; }
        public DbSet<ShipmentState> shipmentState { get; set; }

    }
}
