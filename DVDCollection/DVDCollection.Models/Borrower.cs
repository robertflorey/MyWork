using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.Models
{
    public class Borrower
    {
        public int BorrowerId { get; set; }
        public string Name { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public DateTime? CheckInDate { get; set; }
        public int? DVDId { get; set; }
    }
}
