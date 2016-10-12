using DVDCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.BLL.Tests.MockBorrowerRepos
{
    public class WorkingMockBorrowerRepository : IBorrowerRepository
    {
        private static List<Borrower> _borrowers;

        static WorkingMockBorrowerRepository()
        {
            _borrowers = new List<Borrower>
            {
                new Borrower
                {
                    BorrowerId=1,
                    Name= "Joe",
                    CheckOutDate= new DateTime(2016,08,15),
                    CheckInDate= new DateTime(2016,09,15),
                    DVDId= 1
                },
                new Borrower
                {
                    BorrowerId= 2,
                    Name= "John"
                }
            };
        }

        public bool AddBorrower(Borrower borrower)
        {
            var result = borrower;
            return true;
        }

        public void BorrowDVD(int borrowerId, int dvdId)
        {
            Borrower borrower = new Borrower();
            borrower =GetBorrower(borrowerId);
            borrower.DVDId = dvdId;
        }

        public void BorrowerReturnDVD(int borrowerId)
        {
            Borrower borrower = new Borrower();
            borrower = GetBorrower(borrowerId);
        }

        public IEnumerable<Borrower> GetAllBorrowers()
        {
            return _borrowers;
        }

        public Borrower GetBorrower(int borrowerId)
        {
            Borrower borrower = new Borrower();
            borrower = _borrowers.FirstOrDefault(b => b.BorrowerId == borrowerId);
            return borrower;
        }
    }
}
