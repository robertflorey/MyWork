using FlooringProgram.Models;
using FlooringProgram.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringProgram.BLL
{
    public class OrderManager
    {
        private IOrderRepository orderRepository;
        private IProductRepository productRepository;
        private ITaxesRepository taxesRepository;

        public OrderManager(IOrderRepository orderRepository, IProductRepository productRepository, ITaxesRepository taxesRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.taxesRepository = taxesRepository;
        }

        public List<Order> GetOrders(DateTime identifier)
        {
            return  orderRepository.GetOrders(identifier);
            
        }

        public Products GetProductTypeandCost(string identifier)
        {
            int productChoice;
            int.TryParse(identifier, out productChoice);
            string[] allProducts = GetAllProducts();
            if (productChoice < 1 || productChoice > allProducts.Length - 1)
            {
                return null;
            }
            return productRepository.GetProductTypeandCost(productChoice);
        }

        public string[] GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Taxes GetStateAndTaxRate(string identifier)
        {
            int stateChoice;
            int.TryParse(identifier, out stateChoice);
            string[] allStates = GetAllStates();
            if(stateChoice<1 || stateChoice>allStates.Length-1)
            {
                return null;
            }
            return taxesRepository.GetStateAndTaxRate(stateChoice);
        }

        public string[] GetAllStates()
        {
            return taxesRepository.GetAllStates();
        }

        public Order AddOrder(Order order, DateTime identifier)
        {
            if (GetOrders(identifier)==null)
            {
                order.orderNumber = 1;
            }
            else
            {
                order.orderNumber = GetOrders(identifier).Max(o => o.orderNumber) + 1;
            }
            if(order.area==0 || order.costPerSquareFoot==0 || order.customerName== null || order.laborCost==0 || order.laborCostPerSquareFoot==0)
            {
                return null;
            }
            else if(order.materialCost==0 || order.productType==null || order.state==null || order.tax==0 || order.taxRate==0 || order.total==0)
            {
                return null;
            }
            string[] products = GetAllProducts();
            string[] states = GetAllStates();
            foreach (string item in products)
            {
                string[] productsParts = item.Split(',');
                if(productsParts[0]==order.productType)
                {
                    foreach (string state in states)
                    {
                        string[] statesParts = state.Split(',');
                        if (statesParts[1] == order.state)
                        {
                            return orderRepository.AddOrder(order, identifier);
                        }
                    }
                }
            }
            return null;
        }

        public List<Order> EditOrder(Order order, int orderToEdit, DateTime identifier)
        {
            return orderRepository.EditOrder(order, orderToEdit, identifier);
        }

        public bool RemoveOrder(int orderToRemove, DateTime identifier)
        {
            List<Order> orders = GetOrders(identifier);
            if (orders==null)
            {
                return false;
            }
            else if(orderToRemove<1)
            {
                return false;
            }
            else if (orders.FirstOrDefault(o => o.orderNumber == orderToRemove)==null)
            {
                return false;
            }
            orderRepository.RemoveOrder(orderToRemove, identifier);
            return true;
        }

        public Order userInputOrder(string customerName, Products product, Taxes taxes, decimal area)
        {
            Order order = new Order();
            order.customerName = customerName;
            order.state = taxes.state;
            order.taxRate = taxes.taxRate;
            order.productType = product.productType;
            order.area = area;
            order.costPerSquareFoot = product.costPerSquareFoot;
            order.laborCostPerSquareFoot = product.laborCostPerSquareFoot;
            order.materialCost = Math.Round(order.area * order.costPerSquareFoot, 2);
            order.laborCost = Math.Round(order.area * order.laborCostPerSquareFoot, 2);
            order.tax = Math.Round(order.materialCost * (order.taxRate/100), 2);
            order.total = Math.Round(order.laborCost + order.materialCost + order.tax);

            return order;
        }
    }
}
