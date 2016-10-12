using FlooringProgram.Models;
using FlooringProgram.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Tests.Mocks
{
    class MockOrderRepository : IOrderRepository
    {
        Order order01012013 = new Order
        {
            orderNumber = 1,
            customerName = "Nofx",
            productType = "Linoleum",
            state = "California",
            taxRate = .05m,
            area = 100,
            costPerSquareFoot = 2.50m,
            laborCostPerSquareFoot = 5.00m,
            materialCost = 250m,
            laborCost = 500m,
            tax = 37.50m,
            total = 787.50m
        };

        public Order AddOrder(Order order, DateTime identifier)
        {
            return order;
        }

        public List<Order> EditOrder(Order order, int orderToEdit, DateTime identifier)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders(DateTime identifier)
        {
            List<Order> orderList = new List<Order>();
            if (identifier == new DateTime (2013,01,01))
            {
                orderList.Add(order01012013);
                return orderList;
            }
            else
            {
                return null;
            }
        }

        public bool RemoveOrder(int orderToRemove, DateTime identifier)
        {
            throw new NotImplementedException();
        }
    }
}
