using Microsoft.EntityFrameworkCore;
using SufferShopDB;
using SufferShopDB.Models;
using SufferShopDB.Repos;
using SufferShopDB.Repos.DBRepos;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SufferShopTest
{
    public class DBRepoTest
    {

        private DBRepo repo;

        private readonly Customer testCustomer = new Customer()
        {
            //Id = -10,
            Name = "Mister Sample",
            Email = "sample.email@sample.email",
            Password = "samplepassword",
            Address = "Sample Place"
        };

        private readonly List<Customer> testCustomers = SampleData.Customers;


        private void Seed(SufferShopContext testcontext)
        {
            // testcontext.Customers.AddRange(testCustomers);
            // testcontext.SaveChanges();

        }

        [Fact]
        public void AddCustomerShouldAdd()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<SufferShopContext>().UseInMemoryDatabase("AddCustomerShouldAdd").Options;
            using var testContext = new SufferShopContext(options);
            repo = new DBRepo(testContext);

            //Act
            repo.AddCustomerAsync(testCustomer);

            //Assert
            using var assertContext = new SufferShopContext(options);
            Assert.NotNull(assertContext.Customers.Single(c => c.Id == testCustomer.Id));

        }


        [Fact]
        public void GetCustomerByEmailShouldGetCustomer()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<SufferShopContext>().UseInMemoryDatabase("GetCustomerByEmailShouldGetCustomer").Options;
            using var testContext = new SufferShopContext(options);
            repo = new DBRepo(testContext);

            //Act
            repo.AddCustomerAsync(testCustomer);

            //Assert
            using var assertContext = new SufferShopContext(options);

            Assert.NotNull(assertContext.Customers.Single(c => c.Email == testCustomer.Email));

        }

    }
}
