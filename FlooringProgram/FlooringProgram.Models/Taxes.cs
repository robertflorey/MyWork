using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class Taxes
    {
        public string stateAbbreviation { get; set; }
        public string state { get; set; }
        public decimal taxRate { get; set; }
    }
}
