using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models.Contracts
{
    public interface ITaxesRepository
    {
        Taxes GetStateAndTaxRate(int identifier);

        string[] GetAllStates();
    }
}
