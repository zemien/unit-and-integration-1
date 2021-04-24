using System.Collections.Generic;
using AutoMapper;
using FakeItEasy;
using ShoppingCartService.BusinessLogic;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Models;
using Xunit;

namespace ShoppingCartServiceTests
{
    public class CheckOutEngineTest
    {
        private Cart CreateMinimalCart()
        {
            return new Cart
            {
                CustomerType = ShoppingCartService.Models.CustomerType.Standard,
                Items = new List<Item>
                {
                    new Item
                    {
                        Price = 100,
                        Quantity = 2
                    }
                }
            };
        }

        [InlineData(CustomerType.Standard, 0)]
        [InlineData(CustomerType.Premium, 10.0)]
        [Theory]
        public void CustomerDiscounts(CustomerType customerType, double customerDiscount)
        {
            var cart = CreateMinimalCart();
            cart.CustomerType = customerType;
            var checkoutEngine = new CheckOutEngine(A.Dummy<IShippingCalculator>(), A.Dummy<IMapper>());

            var result = checkoutEngine.CalculateTotals(cart);

            Assert.Equal(customerDiscount, result.CustomerDiscount);
        }

        [InlineData(CustomerType.Standard, 200)]
        [InlineData(CustomerType.Premium, 180)]
        [Theory]
        public void CartTotals(CustomerType customerType, double total)
        {
            var cart = CreateMinimalCart();
            cart.CustomerType = customerType;
            var checkoutEngine = new CheckOutEngine(A.Dummy<IShippingCalculator>(), A.Dummy<IMapper>());

            var result = checkoutEngine.CalculateTotals(cart);

            Assert.Equal(total, result.Total);
        }
    }
}
