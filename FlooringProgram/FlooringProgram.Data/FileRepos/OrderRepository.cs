using FlooringProgram.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;
using System.Configuration;
using FlooringProgram.Data;

namespace FlooringProgram.Data
{
    public class OrderRepository : IOrderRepository
    {
        public Order AddOrder(Order order, DateTime identifier)
        {
            StreamWriter writer = null;
                if(order.orderNumber == 1)
            { 
                using (FileStream create = File.Create(GetDataFilePath(identifier)))
                {

                }
            }
                using (writer = new StreamWriter(GetDataFilePath(identifier), true))
                {                   
                    writer.Write(order.orderNumber);
                    writer.Write("|");
                    writer.Write(order.customerName);
                    writer.Write("|");
                    writer.Write(order.state);
                    writer.Write("|");
                    writer.Write(order.taxRate);
                    writer.Write("|");
                    writer.Write(order.productType);
                    writer.Write("|");
                    writer.Write(order.area);
                    writer.Write("|");
                    writer.Write(order.costPerSquareFoot);
                    writer.Write("|");
                    writer.Write(order.laborCostPerSquareFoot);
                    writer.Write("|");
                    writer.Write(order.materialCost);
                    writer.Write("|");
                    writer.Write(order.laborCost);
                    writer.Write("|");
                    writer.Write(order.tax);
                    writer.Write("|");
                    writer.Write(order.total);
                    writer.WriteLine();
                }
            return order;
        }

        public List<Order> EditOrder(Order order, int orderToEdit, DateTime identifier)
        {
            string orderNum = orderToEdit.ToString();
            var result = new List<Order>();
            if (File.Exists(GetDataFilePath(identifier)))
            {
                {
                    string[] orders;
                    using (var stream = File.OpenRead(GetDataFilePath(identifier)))
                    using (var reader = new StreamReader(stream))
                    {
                        orders = File.ReadAllLines(GetDataFilePath(identifier));
                        string selectedOrder = orders.First(o => o.StartsWith(orderNum));
                        int line = Array.IndexOf(orders, selectedOrder);
                        selectedOrder = string.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} | {11}",
                            order.orderNumber, order.customerName, order.state, order.taxRate, order.productType, order.area,
                            order.costPerSquareFoot, order.laborCostPerSquareFoot, order.materialCost, order.laborCost, order.tax, order.total);
                        orders[line] = selectedOrder;
                    }
                    File.WriteAllLines(GetDataFilePath(identifier), orders);
                }
            }
            return result;
        }

        public List<Order> GetOrders(DateTime identifier)
        {
            var result = new List<Order>();
            if (File.Exists(GetDataFilePath(identifier)))
            {
                {
                    using (var stream = File.OpenRead(GetDataFilePath(identifier)))
                    using (var reader = new StreamReader(stream))
                    {
                        string line = null;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Order order = new Order();

                            string[] orderParts = line.Split('|');
                            if (orderParts.Length == 12)
                            {

                                int orderNumber;
                                int.TryParse(orderParts[0], out orderNumber);
                                order.orderNumber = orderNumber;

                                order.customerName = orderParts[1];
                                order.state = orderParts[2];

                                decimal taxRate;
                                decimal.TryParse(orderParts[3], out taxRate);
                                order.taxRate = taxRate;

                                order.productType = orderParts[4];

                                int area;
                                int.TryParse(orderParts[5], out area);
                                order.area = area;

                                decimal costPerSquareFoot;
                                decimal.TryParse(orderParts[6], out costPerSquareFoot);
                                order.costPerSquareFoot = costPerSquareFoot;

                                decimal laborCostPerSquareFoot;
                                decimal.TryParse(orderParts[7], out laborCostPerSquareFoot);
                                order.laborCostPerSquareFoot = laborCostPerSquareFoot;

                                decimal materialCost;
                                decimal.TryParse(orderParts[8], out materialCost);
                                order.materialCost = materialCost;

                                decimal laborCost;
                                decimal.TryParse(orderParts[9], out laborCost);
                                order.laborCost = laborCost;

                                decimal tax;
                                decimal.TryParse(orderParts[10], out tax);
                                order.tax = tax;

                                decimal total;
                                decimal.TryParse(orderParts[11], out total);
                                order.total = total;
                                
                            }
                            result.Add(order);
                        }
                    }
                }
                return result;
            }
            return null;
        }

        public bool RemoveOrder(int orderToRemove, DateTime identifier)
        {
            int line;
            string orderNum = orderToRemove.ToString();
            var result = new List<Order>();
            if (File.Exists(GetDataFilePath(identifier)))
            {
                {
                    string[] orders;
                    using (var stream = File.OpenRead(GetDataFilePath(identifier)))
                    using (var reader = new StreamReader(stream))
                    {
                        orders = File.ReadAllLines(GetDataFilePath(identifier));
                        string selectedOrder = orders.First(o => o.StartsWith(orderNum));
                        line = Array.IndexOf(orders, selectedOrder);
                    }
                    if (orders.Length == 1)
                    {
                        File.Delete(GetDataFilePath(identifier));
                    }
                    else if (orders.Length == 2)
                    {
                        if (line == 0)
                        {
                            File.WriteAllLines(GetDataFilePath(identifier), orders.Skip(1));
                        }
                        else
                        {
                            File.WriteAllLines(GetDataFilePath(identifier), orders.Take(1));
                        }
                    }
                    else
                    {
                        if(line == 0)
                        {
                            File.WriteAllLines(GetDataFilePath(identifier), orders.Skip(1));
                        }
                        else if(line == orders.Length-1)
                        {
                            File.WriteAllLines(GetDataFilePath(identifier), orders.Take(line));
                        }
                        else
                        {
                            string[] partOrders = new ArraySegment<string>(orders, 0, line).ToArray();
                            string[] partOrders2 = new ArraySegment<string>(orders, line+1, orders.Length-line-1).ToArray();
                            string[] combinedOrders = partOrders.Concat(partOrders2).ToArray();
                            File.WriteAllLines(GetDataFilePath(identifier), combinedOrders);
                        }
                    }
                }
            }
            return true;
        }

        private string GetDataFilePath(DateTime identifier)
        {

            return Path.Combine(ConfigurationManager.AppSettings["DataFilePath"], string.Format("Orders_{0:MMddyyyy}.txt", identifier));
        }
       
    }
}
