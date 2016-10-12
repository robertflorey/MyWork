using FlooringProgram.Models;
using FlooringProgram.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Data
{
    public class TaxesRepository : ITaxesRepository
    {
        public Taxes GetStateAndTaxRate(int identifier)
        {
            using (var stream = File.OpenRead(GetTaxesFilePath()))
            using (var reader = new StreamReader(stream))
            {
                
                int count = 0;
                while (count < identifier)
                {
                    reader.ReadLine();
                    ++count;
                }
                
                Taxes stateChoice = new Taxes();
                string line = reader.ReadLine();
                string[] taxesParts = line.Split(',');
                if(taxesParts.Length==3)
                {
                    stateChoice.stateAbbreviation = taxesParts[0];
                    stateChoice.state = taxesParts[1];

                    decimal taxRate;
                    decimal.TryParse(taxesParts[2], out taxRate);
                    stateChoice.taxRate = taxRate;

                }
                return stateChoice;
            }
        }
        public string[] GetAllStates()
        {
            string[] taxes = File.ReadAllLines(GetTaxesFilePath());
            return taxes;
        }

        private string GetTaxesFilePath()
        {
            return Path.Combine(ConfigurationManager.AppSettings["DataFilePath"], string.Format("Taxes.txt"));
        }
    }
}
