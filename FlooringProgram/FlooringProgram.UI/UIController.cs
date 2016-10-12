using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringProgram.BLL;
using FlooringProgram.Models.Contracts;
using FlooringProgram.Models;
using FlooringProgram.Data;

namespace FlooringProgram.UI
{
    class UIController
    {
        OrderManager orderLibrary = OrderManagerFactory.GetOrderManager();
        public UIController()
        {
            
            int choice;
            bool quit = false;
            while (!quit)
            {
                StartMenu display = new StartMenu();
                choice = display.GetUserPick();
                switch (choice)
                {
                    case 5:
                        {
                            Console.WriteLine("Are you sure you want to quit? y/n");
                            if (Console.ReadLine()=="y")
                            {
                                quit = true;
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 4:
                        {
                            DateTime date = GetUserDate();
                            Console.WriteLine("Please verify date.");
                            List<Order> existingOrders = GetOrdersDisplay();
                            if (existingOrders == null)
                            {
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                            Console.WriteLine("Select order number that you would like to remove.");
                            string possibleOrderNumber = Console.ReadLine();
                            int orderToRemove;
                            int.TryParse(possibleOrderNumber, out orderToRemove);
                            Order order = existingOrders.FirstOrDefault(o => o.orderNumber == orderToRemove);
                            if (order==null)
                            {
                                Console.WriteLine("You entered an invalid order number.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Console.WriteLine("Order number: {0}", order.orderNumber);
                            Console.WriteLine("Customer Name: {0}", order.customerName);
                            Console.WriteLine("State: {0}", order.state);
                            Console.WriteLine("Tax rate: {0}", order.taxRate);
                            Console.WriteLine("Product: {0}", order.productType);
                            Console.WriteLine("Area: {0}", order.area);
                            Console.WriteLine("Cost pSqft: {0}", order.costPerSquareFoot);
                            Console.WriteLine("Labor cost psqft: {0}", order.laborCostPerSquareFoot);
                            Console.WriteLine("Material cost: {0}", order.materialCost);
                            Console.WriteLine("Labor cost: {0}", order.laborCost);
                            Console.WriteLine("Tax: {0}", order.tax);
                            Console.WriteLine("Total: {0}", order.total);
                            Console.WriteLine("Are you sure you want to remove this order? y/n");
                            if (Console.ReadLine() == "y")
                            {
                                if(orderLibrary.RemoveOrder(order.orderNumber, date)==false)
                                {
                                    Console.WriteLine("Order removal failed.");
                                }
                                else
                                {
                                    Console.WriteLine("Order removed");
                                }
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            DateTime date = GetUserDate();
                            Console.WriteLine("Please verify date.");
                            List<Order> existingOrders = GetOrdersDisplay();
                            if(existingOrders==null)
                            {
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                            Console.WriteLine("Select order number that you would like to edit.");
                            string possibleOrderNumber = Console.ReadLine();
                            int orderToEdit;
                            int.TryParse(possibleOrderNumber, out orderToEdit);
                            Order order = existingOrders.FirstOrDefault(o => o.orderNumber == orderToEdit);
                            Console.WriteLine("Would you like to change the customer's name? y/n");
                            if (Console.ReadLine()=="y")
                            {
                                Console.WriteLine("Please enter a new customer name.");
                                string customer = Console.ReadLine();
                                order.customerName = customer;
                            }
                            else
                            {
                                order.customerName = order.customerName;
                            }
                            Console.WriteLine("Would you like to change the area? y/n");
                            if (Console.ReadLine() == "y")
                            {
                                string possibleArea = Console.ReadLine();
                                int area;
                                int.TryParse(possibleArea, out area);
                                if (area<100 || area>10000)
                                {
                                    Console.WriteLine("You did not enter a valid area.");
                                    Console.ReadKey();
                                    break;
                                }
                                order.area = area;
                            }
                            else
                            {
                                order.area = order.area;
                            }
                            Console.WriteLine("Would you like to change the product? y/n");
                            if(Console.ReadLine()== "y")
                            {
                                Products product = GetProduct();
                                if (product == null)
                                {
                                    Console.WriteLine("Your product choice was invalid. Press enter to return to main menu.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                order.productType = product.productType;
                                order.costPerSquareFoot = product.costPerSquareFoot;
                                order.laborCostPerSquareFoot = product.laborCostPerSquareFoot;
                            }
                            else
                            {
                                order.productType = order.productType;
                                order.costPerSquareFoot = order.costPerSquareFoot;
                                order.laborCostPerSquareFoot = order.laborCostPerSquareFoot;
                            }
                            Console.WriteLine("Would you like to change the state? y/n");
                            if (Console.ReadLine()== "y")
                            {
                                Taxes state = GetState();
                                if (state == null)
                                {
                                    Console.WriteLine("Your state choice was invalid. Press enter to return to main menu.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                order.state = state.state;
                                order.taxRate = state.taxRate;
                            }
                            else
                            {
                                order.state = order.state;
                                order.taxRate = order.taxRate;
                            }
                            order.materialCost = Math.Round(order.area * order.costPerSquareFoot, 2);
                            order.laborCost = Math.Round(order.area * order.laborCostPerSquareFoot, 2);
                            order.tax = Math.Round(order.materialCost * (order.taxRate / 100), 2);
                            order.total = Math.Round(order.laborCost + order.materialCost + order.tax);

                            Console.WriteLine("Order number: {0}", order.orderNumber);
                            Console.WriteLine("Customer Name: {0}", order.customerName);
                            Console.WriteLine("State: {0}", order.state);
                            Console.WriteLine("Tax rate: {0}", order.taxRate);
                            Console.WriteLine("Product: {0}", order.productType);
                            Console.WriteLine("Area: {0}", order.area);
                            Console.WriteLine("Cost pSqft: {0}", order.costPerSquareFoot);
                            Console.WriteLine("Labor cost psqft: {0}", order.laborCostPerSquareFoot);
                            Console.WriteLine("Material cost: {0}", order.materialCost);
                            Console.WriteLine("Labor cost: {0}", order.laborCost);
                            Console.WriteLine("Tax: {0}", order.tax);
                            Console.WriteLine("Total: {0}", order.total);
                            Console.WriteLine("Are you sure you want to change this order? y/n");
                            if (Console.ReadLine() == "y")
                            {
                                orderLibrary.EditOrder(order, order.orderNumber, date);
                            }

                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            DateTime date = GetUserDate();
                            DateTime earliestDate = new DateTime(2000,01,01);
                            if(date < earliestDate)
                            {
                                Console.WriteLine("Can't add orders before the year 2000.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Console.WriteLine("Please enter company name.");
                            string customerName = Console.ReadLine();

                            int area;
                            Console.WriteLine("Please enter an area. Min=100, Max=10000");
                            string userArea = Console.ReadLine();
                            int.TryParse(userArea, out area);
                            if(area<100)
                            {
                                Console.WriteLine("That area is too small");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else if(area>10000)
                            {
                                Console.WriteLine("That area is too large");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                            Products product = GetProduct();
                            if (product == null)
                            {
                                Console.WriteLine("Your product choice was invalid. Press enter to return to main menu.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Taxes state = GetState();
                            if (state==null)
                            {
                                Console.WriteLine("Your state choice was invalid. Press enter to return to main menu.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                            Order order = orderLibrary.userInputOrder(customerName, product, state, area);
                            string taxRate = order.taxRate.ToString();
                            string Area = order.area.ToString();
                            string costPSqFt = order.costPerSquareFoot.ToString();
                            string laborCostPSqFt = order.laborCostPerSquareFoot.ToString();
                            string laborCost = order.laborCost.ToString();
                            string materialCost = order.materialCost.ToString();
                            string tax = order.tax.ToString();
                            string total = order.total.ToString();
                            string orderDate = date.ToString();

                            Console.WriteLine("Order date: {0}", orderDate);
                            Console.WriteLine("Customer Name: {0}", order.customerName);
                            Console.WriteLine("State: {0}", order.state);
                            Console.WriteLine("Tax rate: {0}", order.taxRate);
                            Console.WriteLine("Product: {0}", order.productType);
                            Console.WriteLine("Area: {0}", order.area);
                            Console.WriteLine("Cost pSqft: {0}", order.costPerSquareFoot);
                            Console.WriteLine("Labor cost psqft: {0}", order.laborCostPerSquareFoot);
                            Console.WriteLine("Material cost: {0}", order.materialCost);
                            Console.WriteLine("Labor cost: {0}", order.laborCost);
                            Console.WriteLine("Tax: {0}", order.tax);
                            Console.WriteLine("Total: {0}", order.total);
                            Console.WriteLine("Is this order correct? (y/n)");

                            if (Console.ReadLine() == "y")
                            {
                                if(orderLibrary.AddOrder(order, date)==null)
                                {
                                    Console.WriteLine("Order add failed");
                                }
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 1:
                    default:
                        GetOrdersDisplay();
                        
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        private DateTime GetUserDate()
        {
            Console.WriteLine("Please enter a date, yyyy,mm,dd");
            string userDate = Console.ReadLine();
            DateTime validDate;
            DateTime.TryParse(userDate, out validDate);
            if(validDate==DateTime.MinValue)
            {
                Console.WriteLine("You entered an invalid date.");
                Console.ReadKey();
                Console.Clear();
            }
            return validDate;
        }

        private List<Order> GetViewOrders()
        {
            DateTime date = GetUserDate();
            List<Order> orders = new List<Order>();
            orders = orderLibrary.GetOrders(date);
            return orders;
        }

        private List<Order> GetOrdersDisplay()
        {
            List<Order> orderList = GetViewOrders();
            if (orderList != null)
            {
                foreach (Order order in orderList)
                {
                    //string orderNumber = order.orderNumber.ToString();
                    //string taxRate = order.taxRate.ToString();
                    //string area = order.area.ToString();
                    //string costPSqFt = order.costPerSquareFoot.ToString();
                    //string laborCostPSqFt = order.laborCostPerSquareFoot.ToString();
                    //string laborCost = order.laborCost.ToString();
                    //string materialCost = order.materialCost.ToString();
                    //string tax = order.tax.ToString();
                    //string total = order.total.ToString();

                    Console.WriteLine("Order number: {0}", order.orderNumber);
                    Console.WriteLine("Customer Name: {0}", order.customerName);
                    Console.WriteLine("State: {0}", order.state);
                    Console.WriteLine("Tax rate: {0}", order.taxRate);
                    Console.WriteLine("Product: {0}", order.productType);
                    Console.WriteLine("Area: {0}", order.area);
                    Console.WriteLine("Cost pSqft: {0}", order.costPerSquareFoot);
                    Console.WriteLine("Labor cost psqft: {0}", order.laborCostPerSquareFoot);
                    Console.WriteLine("Material cost: {0}", order.materialCost);
                    Console.WriteLine("Labor cost: {0}", order.laborCost);
                    Console.WriteLine("Tax: {0}", order.tax);
                    Console.WriteLine("Total: {0}", order.total);
                }
            }
            else
            {
                Console.WriteLine("No orders exist for that date.");    
            }
            return orderList;
        }

        private Products GetProduct()
        {
            int index = 0;
            foreach (string line in orderLibrary.GetAllProducts())
            {
                Console.WriteLine(string.Format("{0}. {1}", index, line));
                index++;
            }
            Console.WriteLine("Please enter number for product of order.");
            string userProductNumber = Console.ReadLine();
            Products productChoice = orderLibrary.GetProductTypeandCost(userProductNumber);
            return productChoice;
        }

        private Taxes GetState()
        {
            int index = 0;
            foreach (string line in orderLibrary.GetAllStates())
            {

                Console.WriteLine(string.Format("{0}. {1}", index, line));
                index++;
            }
            Console.WriteLine("Please enter number for state of order.");
            string userStateNumber = Console.ReadLine();
            Taxes stateChoice = orderLibrary.GetStateAndTaxRate(userStateNumber);
            return stateChoice;
        }
    }
}
