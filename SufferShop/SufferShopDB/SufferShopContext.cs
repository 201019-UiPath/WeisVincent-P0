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

        public DbSet<LocationStockedProduct> LocationStockedProducts { get; set; }

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

            modelBuilder.Entity<LocationStockedProduct>().HasNoKey();

            modelBuilder.Entity<OrderedProduct>().HasNoKey();




            modelBuilder.Entity<Customer>().HasData(SampleData.Customers);
            modelBuilder.Entity<Location>().HasData(SampleData.Locations);
            modelBuilder.Entity<Order>().HasData(SampleData.Orders);
            modelBuilder.Entity<Manager>().HasData(SampleData.Managers);
            modelBuilder.Entity<Product>().HasData(SampleData.Products);


            #region Manual Model Relationship Mapping
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
            
            // Order - Product One to Many Relationship
            modelBuilder.Entity<LocationStockedProduct>()
                .HasOne<Order>(lsp => lsp.Order)
                .WithMany(o => o.OrderedProducts)
                .HasForeignKey(lsp => lsp.OrderID);
            */
            #endregion
        }

    }
}
