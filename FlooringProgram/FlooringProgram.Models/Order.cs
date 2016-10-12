using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class Order
    {
        public int orderNumber { get; set; }
        public string customerName { get; set; }
        public string state { get; set; }
        public decimal taxRate { get; set; }
        public string productType { get; set; }
        public decimal area { get; set; }
        public decimal costPerSquareFoot { get; set; }
        public decimal laborCostPerSquareFoot { get; set; }
        public decimal materialCost { get; set; }
        public decimal laborCost { get; set; }
        public decimal tax { get; set; }
        public decimal total { get; set; }

    }
}
