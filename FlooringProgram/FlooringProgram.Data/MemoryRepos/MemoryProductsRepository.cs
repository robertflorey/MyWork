using FlooringProgram.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class MemoryProductsRepository : IProductRepository
    {
        public string[] GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Products GetProductTypeandCost(int identifier)
        {
            throw new NotImplementedException();
        }
    }
}
