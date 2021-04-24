using System;
using System.Collections.Generic;
using AutoMapper;
using FakeItEasy;
using ShoppingCartService.BusinessLogic;
using ShoppingCartService.DataAccess.Entities;
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

        [Fact]
        public void NonPremiumCustomerGetsNoDiscount()
        {
            var cart = CreateMinimalCart();
            var checkoutEngine = new CheckOutEngine(A.Dummy<IShippingCalculator>(), A.Dummy<IMapper>());

            var result = checkoutEngine.CalculateTotals(cart);

            Assert.Equal(0, result.CustomerDiscount);
        }

        [Fact]
        public void PremiumCustomerGets10PercentDiscount()
        {
            var cart = CreateMinimalCart();
            cart.CustomerType = ShoppingCartService.Models.CustomerType.Premium;
            var checkoutEngine = new CheckOutEngine(A.Dummy<IShippingCalculator>(), A.Dummy<IMapper>());

            var result = checkoutEngine.CalculateTotals(cart);

            Assert.Equal(10.0, result.CustomerDiscount);
        }

        [Fact]
        public void StandardCustomerTotal()
        {
            var cart = CreateMinimalCart();
            var checkoutEngine = new CheckOutEngine(A.Dummy<IShippingCalculator>(), A.Dummy<IMapper>());

            var result = checkoutEngine.CalculateTotals(cart);

            Assert.Equal(200, result.Total);
        }

        [Fact]
        public void PremiumCustomerTotal()
        {
            var cart = CreateMinimalCart();
            cart.CustomerType = ShoppingCartService.Models.CustomerType.Premium;
            var checkoutEngine = new CheckOutEngine(A.Dummy<IShippingCalculator>(), A.Dummy<IMapper>());

            var result = checkoutEngine.CalculateTotals(cart);

            Assert.Equal(180, result.Total);
        }
    }
}
