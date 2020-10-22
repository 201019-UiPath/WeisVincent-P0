using System;
using Xunit;
using SufferShopLib;

namespace SufferShopTest
{
    public class CustomerSampleTest
    {
        //[Fact]// As opposed to theory
        [Theory]
        [InlineData("4807973097")]
        [InlineData("797-3097")]
        public void AddCustomerPhoneNumberShouldAddCustomerPhoneNumber(string phonenumber)
        {
            // Arrange (Arranging artifacts I might need during testing)

            CustomerSample customer = new CustomerSample();
            customer.AddPhoneNumber(phonenumber);

            Assert.Equal(phonenumber, customer.PhoneNumbers.Peek());

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void AddCustomerPhoneNumberShouldThrowArgumentException(string phonenumber)
        {
            // Arrange (Arranging artifacts I might need during testing)

            CustomerSample customer = new CustomerSample();

            // Here, the act and assert are the same thing.
            Assert.Throws<ArgumentException>(() => customer.AddPhoneNumber(phonenumber));

        }
    }
}
