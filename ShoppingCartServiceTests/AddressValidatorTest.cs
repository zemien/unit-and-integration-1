using ShoppingCartService.BusinessLogic.Validation;
using ShoppingCartService.Models;
using Xunit;

namespace ShoppingCartServiceTests
{
    public class AddressValidatorTest
    {
        [Fact]
        public void AddressIsNotNull()
        {
            var addressValidator = new AddressValidator();

            Assert.False(addressValidator.IsValid(null));
        }

        [InlineData(null, "City", "Street")]
        [InlineData("", "City", "Street")]
        [InlineData("Country", null, "Street")]
        [InlineData("Country", "", "Street")]
        [InlineData("Country", "City", null)]
        [InlineData("Country", "City", "")]
        [Theory]
        public void InvalidAddresses(string country, string city, string street)
        {
            var addressValidator = new AddressValidator();

            var address = new Address
            {
                Country = country,
                City = city,
                Street = street
            };

            Assert.False(addressValidator.IsValid(address));
        }

        [Fact]
        public void AddressIsValid()
        {
            var addressValidator = new AddressValidator();

            var address = new Address
            {
                Country = "Country",
                City = "City",
                Street = "Street"
            };

            Assert.True(addressValidator.IsValid(address));
        }
    }
}
