﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnOutOfStockProductItShouldReturnAnError()
        {
            var user = new User("wescleymatos", "1q2w3e4r");
            var customer = new Customer("Wescley", "Matos", "wescleymatos@gmail.com", user);
            var mouse = new Product("Mouse", 299, "mouse.jpg", 0);

            var order = new Order(customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnOutOfStockProductItShouldUpdateQuantityOnHand()
        {
            var user = new User("wescleymatos", "1q2w3e4r");
            var customer = new Customer("Wescley", "Matos", "wescleymatos@gmail.com", user);
            var mouse = new Product("Mouse", 299, "mouse.jpg", 20);

            var order = new Order(customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.AreEqual(18, mouse.QuantityOnHand);
        }
    }
}
