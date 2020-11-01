using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using System.IO;

namespace SufferShopDB
{
    public class SufferShopContext : DbContext
    {

        public SufferShopContext(DbContextOptions options) : base(options)
        {

        }

        public SufferShopContext()
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<InventoryLineItem> InventoryLineItems { get; set; }

        public DbSet<OrderLineItem> OrderLineItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("SufferShopDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //TODO: Configure modelBuilder to implement model relationships
            /* Needs: Customer to Orders OTM
            Order to Customer OTO
            */

            modelBuilder.Entity<Customer>().HasKey("Id");

            modelBuilder.Entity<Location>().HasKey("Id");

            modelBuilder.Entity<Manager>().HasKey("Id");

            modelBuilder.Entity<Order>().HasKey("Id");

            modelBuilder.Entity<Product>().HasKey("Id");

            modelBuilder.Entity<InventoryLineItem>().HasNoKey();

            modelBuilder.Entity<OrderLineItem>().HasNoKey();




            modelBuilder.Entity<Customer>().HasData(SampleData.Customers);
            modelBuilder.Entity<Location>().HasData(SampleData.Locations);
            modelBuilder.Entity<Order>().HasData(SampleData.Orders);
            modelBuilder.Entity<Manager>().HasData(SampleData.Managers);
            modelBuilder.Entity<Product>().HasData(SampleData.Products);

            modelBuilder.Entity<InventoryLineItem>().HasData(SampleData.InventoryLineItems);
            modelBuilder.Entity<OrderLineItem>().HasData(SampleData.OrderLineItems);



            #region Manual Model Relationship Mapping

            #region Order - Product Many to Many Relationship (OrderLineItem)
            modelBuilder.Entity<OrderLineItem>()
                .HasKey(oli => new { oli.OrderId, oli.ProductId });
            modelBuilder.Entity<OrderLineItem>()
                .HasOne(oli => oli.Order)
                .WithMany(o => o.OrderLineItems)
                .HasForeignKey(oli => oli.OrderId);
            modelBuilder.Entity<OrderLineItem>()
                .HasOne(oli => oli.Product)
                .WithMany(o => o.OrdersWithProduct)
                .HasForeignKey(oli => oli.ProductId);
            #endregion

            #region Location - Product Many to Many Relationship (InventoryLineItem)
            modelBuilder.Entity<InventoryLineItem>()
                .HasKey(ili => new { ili.LocationId, ili.ProductId });
            modelBuilder.Entity<InventoryLineItem>()
                .HasOne(ili => ili.Location)
                .WithMany(o => o.InventoryLineItems)
                .HasForeignKey(ili => ili.LocationId);
            modelBuilder.Entity<InventoryLineItem>()
                .HasOne(oli => oli.Product)
                .WithMany(o => o.LocationsWithProduct)
                .HasForeignKey(oli => oli.ProductId);
            #endregion

            /*
            // Location - Product Many to Many Relationship
            modelBuilder.Entity<LocationStockedProduct>()
                .HasOne(lsp => lsp.Location)
                .WithMany(l => l.ProductStock)
                .HasForeignKey(lsp => lsp.LocationID);

            // Product - Location Many to Many Relationship
            modelBuilder.Entity<LocationStockedProduct>()
                .HasOne(lsp => lsp.Product)
                .WithMany(p => p.LocationsStockedAt)
                .HasForeignKey(lsp => lsp.ProductID);

            // Location - Manager One to One Relationship
            modelBuilder.Entity<Location>()
                .HasOne(l => l.Manager)
                .WithOne(m => m.Location)
                .HasForeignKey<Manager>(l => l.LocationID);
            
            // Customer - Order One to Many Relationship
            modelBuilder.Entity<Order>()
                .HasOne<Customer>(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);
            */


            #endregion
        }

    }
}
