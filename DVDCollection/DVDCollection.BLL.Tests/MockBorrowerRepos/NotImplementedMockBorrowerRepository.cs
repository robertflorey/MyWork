using DVDCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.BLL.Tests.MockBorrowerRepos
{
    public class NotImplementedMockBorrowerRepository : IBorrowerRepository
    {
        public bool AddBorrower(Borrower borrower)
        {
            throw new NotImplementedException();
        }

        public void BorrowDVD(int borrowerId, int dvdId)
        {
            throw new NotImplementedException();
        }

        public void BorrowerReturnDVD(int borrowerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Borrower> GetAllBorrowers()
        {
            throw new NotImplementedException();
        }

        public Borrower GetBorrower(int borrowerId)
        {
            throw new NotImplementedException();
        }
    }
}
