using SufferShopLib;
using System;
using Xunit;

namespace SufferShopTest
{
    public class CustomerSampleTest
    {
        

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
