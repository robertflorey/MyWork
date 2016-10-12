using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringProgram.Models.Contracts;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.Tests.Mocks;

namespace FlooringProgram.Tests
{
    [TestFixture]
    public class OrderManagerTests
    {

        [Test]
        public void CanGetOrdersCount()
        {
            DateTime date = new DateTime(2013, 01, 01);
            int expectedCount = 1;
            var orderRepository = new MockOrderRepository();
            var productRepository = new MockProductsRepository();
            var taxesRepository = new MockTaxesRepository();
            OrderManager orderManager = new OrderManager(orderRepository,productRepository,taxesRepository);
            List<Order> actual = orderManager.GetOrders(date);
            Assert.AreEqual(expectedCount, actual.Count);
        }

        [Test]
        public void CanAddOrder()
        {
            var orderRepository = new MockOrderRepository();
            var productRepository = new MockProductsRepository();
            var taxesRepository = new MockTaxesRepository();
            OrderManager orderManager = new OrderManager(orderRepository, productRepository, taxesRepository);
            Order order = new Order { area = 100, costPerSquareFoot = 2, customerName = "a", laborCost = 500, laborCostPerSquareFoot = 5, materialCost = 200, productType = "wood", state = "mn", tax = 10, taxRate = .05m, total = 710 };
            DateTime date = new DateTime(2016, 08, 03);
            var result = orderManager.AddOrder(order, date);
            Assert.IsNotNull(result);
        }

        [Test]
        public void MissingInfoCanNotAddOrder()
        {
            var orderRepository = new MockOrderRepository();
            var productRepository = new MockProductsRepository();
            var taxesRepository = new MockTaxesRepository();
            OrderManager orderManager = new OrderManager(orderRepository, productRepository, taxesRepository);
            Order order = new Order { area = 100, costPerSquareFoot = 2, laborCost = 500, laborCostPerSquareFoot = 5, materialCost = 200, productType = "wood", state = "mn", tax = 10, taxRate = .05m, total = 710 };
            DateTime date = new DateTime(2016, 08, 03);
            var result = orderManager.AddOrder(order, date);
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotRemoveOrderDoesNotExist()
        {
            var orderRepository = new MockOrderRepository();
            var productRepository = new MockProductsRepository();
            var taxesRepository = new MockTaxesRepository();
            OrderManager orderManager = new OrderManager(orderRepository, productRepository, taxesRepository);
            DateTime date = new DateTime(2013, 01, 01);
            int orderToRemove = 3;
            var result = orderManager.RemoveOrder(orderToRemove, date);
            Assert.IsFalse(result);
        }
    }
}
