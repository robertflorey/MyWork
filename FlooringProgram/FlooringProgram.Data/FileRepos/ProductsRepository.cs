using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using FlooringProgram.Models.Contracts;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class ProductsRepository : IProductRepository
    {
        public Products GetProductTypeandCost(int identifier)
        {
            using (var stream = File.OpenRead(GetProductsFilePath()))
            using (var reader = new StreamReader(stream))
            {
                int count = 0;
                while (count < identifier)
                {
                    reader.ReadLine();
                    ++count;
                }
                 
                
                Products productChoice = new Products();
                string line = reader.ReadLine();
                string[] productParts = line.Split(',');
                if (productParts.Length == 3)
                {
                    productChoice.productType = productParts[0];

                    decimal costPSqFt;
                    decimal.TryParse(productParts[1], out costPSqFt);
                    productChoice.costPerSquareFoot = costPSqFt;

                    decimal laborCostPSqFt;
                    decimal.TryParse(productParts[2], out laborCostPSqFt);
                    productChoice.laborCostPerSquareFoot = laborCostPSqFt;
                }
                return productChoice;
            }
            
        }
       

        public string[] GetAllProducts()
        {
            string[] products = File.ReadAllLines(GetProductsFilePath());
            return products;
        }

        private string GetProductsFilePath()
        {
            return Path.Combine(ConfigurationManager.AppSettings["DataFilePath"], string.Format("Products.txt"));
        }
    }
}
