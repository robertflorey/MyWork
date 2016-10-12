using DVDCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.BLL
{
    public class DVDManager
    {
        private IDVDRepository dvdRepository;
        private IBorrowerRepository borrowerRepository;

        public DVDManager(IDVDRepository dvdRepository, IBorrowerRepository borrowerRepository)
        {
            this.dvdRepository = dvdRepository;
            this.borrowerRepository = borrowerRepository;
        }

        public IEnumerable<DVD> GetAllDVDs()
        {
            try
            {
                return dvdRepository.GetAllDVDs();
            }
            catch
            {
                return null;
            }
        }

        public DVD GetDVD(int dvdId)
        {
            DVD dvd = new DVD();
            if (dvdId<1)
            {
                return null;
            }
            try
            {
                dvd = dvdRepository.GetDVD(dvdId);
                if (dvd==null)
                {
                    return null;
                }
                return dvd;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<DVD> GetDVDByTitle(string search)
        {
            return dvdRepository.GetDVDByTitle(search);
        }

        public DVD AddDVD(DVD dvd)
        {
            
            if (dvd.Title == null || dvd.Title=="")
            {
                return null;
            }
            DateTime earliestDate = new DateTime(1920, 1, 1);
            if (dvd.ReleaseDate < earliestDate)
            {
                return null;
            }
            try
            {
                return dvdRepository.AddDVD(dvd);
            }
            catch
            {
                return null;
            }
        }

        public bool EditDVD(DVD dvd)
        {
            if (dvd.Title==null || dvd.Title=="")
            {
                return false;
            }
            DateTime earliestDate = new DateTime(1920, 1, 1);
            if (dvd.ReleaseDate < earliestDate)
            {
                return false;
            }
            try
            {
                dvdRepository.EditDVD(dvd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveDVD(int dvdId)
        {
            if(dvdId<1)
            {
                return false;
            }
            DVD dvd = new DVD();
            try
            {
                dvd = GetDVD(dvdId);
                if(dvd==null)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            if(dvd== null || dvd.BorrowerId != null)
            {
                return false;
            }
            try
            {
                if(dvdRepository.RemoveDVD(dvdId)==false)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LendDVD(int dvdId, int borrowerId)
        {
            Borrower borrower = new Borrower();
            try
            {
                borrower = GetBorrower(borrowerId);
                if (borrower==null)
                {
                    return false;
                }
                DVD dvd = new DVD();
                dvd = GetDVD(dvdId);
                if(dvd == null)
                {
                    return false;
                }
                if (dvd.BorrowerId != null)
                {
                    return false;
                }
                dvdRepository.LendDVD(dvdId, borrowerId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ReturnDVD(int dvdId)
        {
            if (dvdId < 1)
            {
                return false;
            }
            try
            {
                if (GetDVD(dvdId) == null)
                {
                    return false;
                }
                dvdRepository.ReturnDVD(dvdId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Borrower> GetAllBorrowers()
        {
            try
            {
                var borrowers = borrowerRepository.GetAllBorrowers();
                if(borrowers==null)
                {
                    return null;
                }
                else
                {
                    return borrowers;
                }
            }
            catch
            {
                return null;
            }
        }

        public Borrower GetBorrower(int borrowerId)
        {
            Borrower borrower = new Borrower();
            if (borrowerId<1)
            {
                return null;
            }
            try
            {
                borrower = borrowerRepository.GetBorrower(borrowerId);
                if(borrower==null)
                {
                    return null;
                }
                return borrower;
            }
            catch
            {
                return null;
            }
        }

        public Borrower AddBorrower(Borrower borrower)
        {
            if (borrower.Name=="")
            {
                return null;
            }
            try
            {
                if(borrowerRepository.AddBorrower(borrower)==true)
                {
                    return borrower;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool BorrowerReturnDVD(int borrowerId)
        {
            if (borrowerId<1)
            {
                return false;
            }
            Borrower borrower = new Borrower();
            try
            {
                borrower = GetBorrower(borrowerId);
                if (borrower == null || borrower.DVDId == null)
                {
                    return false;
                }
                borrowerRepository.BorrowerReturnDVD(borrowerId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool BorrowDVD(int borrowerId, int dvdId)
        {
            if (borrowerId<1 || dvdId<1)
            {
                return false;
            }
            DVD dvd = new DVD();
            try
            {
                dvd = GetDVD(dvdId);
                if (dvd == null || dvd.BorrowerId != null)
                {
                    return false;
                }
                Borrower borrower = new Borrower();
                borrower = GetBorrower(borrowerId);
                if (borrower == null || borrower.DVDId != null)
                {
                    return false;
                }

                borrowerRepository.BorrowDVD(borrowerId, dvdId);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
