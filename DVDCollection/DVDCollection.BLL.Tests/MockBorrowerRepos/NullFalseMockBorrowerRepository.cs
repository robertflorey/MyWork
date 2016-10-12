using DVDCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.BLL.Tests.MockBorrowerRepos
{
    class NullFalseMockBorrowerRepository : IBorrowerRepository
    {
        public bool AddBorrower(Borrower borrower)
        {
            return false;
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
            return null;
        }

        public Borrower GetBorrower(int borrowerId)
        {
            return null;
        }
    }
}
