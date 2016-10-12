using FlooringProgram.BLL;
using FlooringProgram.Data;
using FlooringProgram.Data.MemoryRepos;
using FlooringProgram.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI
{
    public static class OrderManagerFactory
    {
        public static OrderManager GetOrderManager()
        {
            OrderManager manager;
            if(ConfigurationManager.AppSettings["mode"]=="file")
            {
                IOrderRepository repoA = new OrderRepository();
                IProductRepository repoB = new ProductsRepository();
                ITaxesRepository repoC = new TaxesRepository();
                manager = new OrderManager(repoA, repoB, repoC);
            }
            else
            {
                IOrderRepository repoA = new MemoryOrderRepository();
                IProductRepository repoB = new MemoryProductsRepository();
                ITaxesRepository repoC = new MemoryTaxesRepository();
                manager = new OrderManager(repoA, repoB, repoC);
            }
            return manager;
        }
    }
}
