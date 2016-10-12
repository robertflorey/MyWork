using FlooringProgram.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data.MemoryRepos
{
    public class MemoryTaxesRepository : ITaxesRepository
    {
        public string[] GetAllStates()
        {
            throw new NotImplementedException();
        }

        public Taxes GetStateAndTaxRate(int identifier)
        {
            throw new NotImplementedException();
        }
    }
}
