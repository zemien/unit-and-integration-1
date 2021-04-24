using System.Collections.Generic;
using ShoppingCartService.BusinessLogic;
using ShoppingCartService.Models;
using Xunit;

namespace ShoppingCartServiceTests
{
    public class ShippingCalculatorTest
    {

        [InlineData(ShippingMethod.Standard, CustomerType.Standard, 100, 100)]
        [InlineData(ShippingMethod.Expedited, CustomerType.Standard, 100, 120)]
        [InlineData(ShippingMethod.Priority, CustomerType.Standard, 100, 200)]
        [InlineData(ShippingMethod.Express, CustomerType.Standard, 100, 250)]
        [InlineData(ShippingMethod.Standard, CustomerType.Premium, 100, 100)]
        [InlineData(ShippingMethod.Expedited, CustomerType.Premium, 100, 100)]
        [InlineData(ShippingMethod.Priority, CustomerType.Premium, 100, 100)]
        [InlineData(ShippingMethod.Express, CustomerType.Premium, 100, 250)]
        [Theory]
        public void CalculateShippingMethodCost(ShippingMethod shippingMethod, CustomerType customerType, double baseCost, double shippingMethodCost)
        {
            var shippingCalculator = new ShippingCalculator();
            var result = shippingCalculator.CalculateShippingMethodCost(baseCost, shippingMethod, customerType);

            Assert.Equal(shippingMethodCost, result);
        }

        [MemberData(nameof(CalculateTravelCostData))]
        [Theory]
        public void TravelCostForDifferentCountry(Address destination, uint numberOfItems, double travelCost)
        {
            var origin = new Address
            {
                Country = "USA",
                City = "Dallas",
                Street = "1234 left lane."
            };

            var result = ShippingCalculator.CalculateTravelCost(origin, destination, numberOfItems);

            Assert.Equal(travelCost, result);
        }

        public static List<object[]> CalculateTravelCostData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new Address
                    {
                        Country = "NZ",
                        City = "Auckland",
                        Street = "1234 right lane."
                    },
                    1,
                    15.0
                },
                new object[]
                {
                    new Address
                    {
                        Country = "USA",
                        City = "New York",
                        Street = "1234 right lane."
                    },
                    1,
                    2.0
                },
                new object[]
                {
                    new Address
                    {
                        Country = "USA",
                        City = "Dallas",
                        Street = "1234 right lane."
                    },
                    1,
                    1.0
                },
            };
        }
    }
}
