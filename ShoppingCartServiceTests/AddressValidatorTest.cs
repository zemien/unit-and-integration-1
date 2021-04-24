using System;
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

        [Fact]
        public void CountryIsNotNull()
        {
            var addressValidator = new AddressValidator();

            var address = new Address
            {
                Country = null,
                City = "City",
                Street = "Street"
            };

            Assert.False(addressValidator.IsValid(address));
        }

        [Fact]
        public void CountryIsNotEmpty()
        {
            var addressValidator = new AddressValidator();

            var address = new Address
            {
                Country = string.Empty,
                City = "City",
                Street = "Street"
            };

            Assert.False(addressValidator.IsValid(address));
        }

        [Fact]
        public void CityIsNotNull()
        {
            var addressValidator = new AddressValidator();

            var address = new Address
            {
                Country = "Country",
                City = null,
                Street = "Street"
            };

            Assert.False(addressValidator.IsValid(address));
        }

        [Fact]
        public void CityIsNotEmpty()
        {
            var addressValidator = new AddressValidator();

            var address = new Address
            {
                Country = "Country",
                City = string.Empty,
                Street = "Street"
            };

            Assert.False(addressValidator.IsValid(address));
        }

        [Fact]
        public void StreetIsNotNull()
        {
            var addressValidator = new AddressValidator();

            var address = new Address
            {
                Country = "Country",
                City = "City",
                Street = null
            };

            Assert.False(addressValidator.IsValid(address));
        }

        [Fact]
        public void StreetIsNotEmpty()
        {
            var addressValidator = new AddressValidator();

            var address = new Address
            {
                Country = "Country",
                City = "City",
                Street = string.Empty
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
