using System;
using ShoppingCartService.BusinessLogic;
using ShoppingCartService.Models;
using Xunit;

namespace ShoppingCartServiceTests
{
    public class ShippingCalculatorTest
    {
        [Fact]
        public void StandardCustomerStandardShipping()
        {
            var shippingCalculator = new ShippingCalculator();
            var result = shippingCalculator.CalculateShippingMethodCost(
                100,
                ShoppingCartService.Models.ShippingMethod.Standard,
                ShoppingCartService.Models.CustomerType.Standard);

            Assert.Equal(100, result);
        }

        [Fact]
        public void StandardCustomerExpeditedShipping()
        {
            var shippingCalculator = new ShippingCalculator();
            var result = shippingCalculator.CalculateShippingMethodCost(
                100,
                ShoppingCartService.Models.ShippingMethod.Expedited,
                ShoppingCartService.Models.CustomerType.Standard);

            Assert.Equal(120, result);
        }

        [Fact]
        public void StandardCustomerPriorityShipping()
        {
            var shippingCalculator = new ShippingCalculator();
            var result = shippingCalculator.CalculateShippingMethodCost(
                100,
                ShoppingCartService.Models.ShippingMethod.Priority,
                ShoppingCartService.Models.CustomerType.Standard);

            Assert.Equal(200, result);
        }

        [Fact]
        public void StandardCustomerExpressShipping()
        {
            var shippingCalculator = new ShippingCalculator();
            var result = shippingCalculator.CalculateShippingMethodCost(
                100,
                ShoppingCartService.Models.ShippingMethod.Express,
                ShoppingCartService.Models.CustomerType.Standard);

            Assert.Equal(250, result);
        }

        [Fact]
        public void PremiumCustomerStandardShipping()
        {
            var shippingCalculator = new ShippingCalculator();
            var result = shippingCalculator.CalculateShippingMethodCost(
                100,
                ShoppingCartService.Models.ShippingMethod.Standard,
                ShoppingCartService.Models.CustomerType.Premium);

            Assert.Equal(100, result);
        }

        [Fact]
        public void PremiumCustomerExpeditedShipping()
        {
            var shippingCalculator = new ShippingCalculator();
            var result = shippingCalculator.CalculateShippingMethodCost(
                100,
                ShoppingCartService.Models.ShippingMethod.Expedited,
                ShoppingCartService.Models.CustomerType.Premium);

            Assert.Equal(100, result);
        }

        [Fact]
        public void PremiumCustomerPriorityShipping()
        {
            var shippingCalculator = new ShippingCalculator();
            var result = shippingCalculator.CalculateShippingMethodCost(
                100,
                ShoppingCartService.Models.ShippingMethod.Priority,
                ShoppingCartService.Models.CustomerType.Premium);

            Assert.Equal(100, result);
        }

        [Fact]
        public void PremiumCustomerExpressShipping()
        {
            var shippingCalculator = new ShippingCalculator();
            var result = shippingCalculator.CalculateShippingMethodCost(
                100,
                ShoppingCartService.Models.ShippingMethod.Express,
                ShoppingCartService.Models.CustomerType.Premium);

            Assert.Equal(250, result);
        }

        [Fact]
        public void TravelCostForDifferentCountry()
        {
            var origin = new Address
            {
                Country = "USA",
                City = "Dallas",
                Street = "1234 left lane."
            };

            var destination = new Address
            {
                Country = "NZ",
                City = "Auckland",
                Street = "1234 right lane."
            };

            var result = ShippingCalculator.CalculateTravelCost(origin, destination, 1);

            Assert.Equal(15.0, result);
        }

        [Fact]
        public void TravelCostForDifferentCity()
        {
            var origin = new Address
            {
                Country = "USA",
                City = "Dallas",
                Street = "1234 left lane."
            };

            var destination = new Address
            {
                Country = "USA",
                City = "New York",
                Street = "1234 right lane."
            };

            var result = ShippingCalculator.CalculateTravelCost(origin, destination, 1);

            Assert.Equal(2.0, result);
        }


        [Fact]
        public void TravelCostForSameCity()
        {
            var origin = new Address
            {
                Country = "USA",
                City = "Dallas",
                Street = "1234 left lane."
            };

            var destination = new Address
            {
                Country = "USA",
                City = "Dallas",
                Street = "1234 right lane."
            };

            var result = ShippingCalculator.CalculateTravelCost(origin, destination, 1);

            Assert.Equal(1.0, result);
        }
    }
}
