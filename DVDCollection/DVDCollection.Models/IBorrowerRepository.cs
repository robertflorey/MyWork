using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.Models
{
    public interface IBorrowerRepository
    {
        IEnumerable<Borrower> GetAllBorrowers();
        Borrower GetBorrower(int borrowerId);
        bool AddBorrower(Borrower borrower);
        void BorrowerReturnDVD(int borrowerId);
        void BorrowDVD(int borrowerId, int dvdId);
    }
}
