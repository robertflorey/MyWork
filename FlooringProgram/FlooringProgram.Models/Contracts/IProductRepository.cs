using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models.Contracts
{
    public interface IProductRepository
    {
        string[] GetAllProducts();

        Products GetProductTypeandCost(int identifier);
    }
}
