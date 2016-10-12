using DVDCollection.BLL;
using DVDCollection.BLL.Tests.MockBorrowerRepos;
using DVDCollection.BLL.Tests.MockDVDRepos;
using DVDCollection.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.BLL.Tests
{
    [TestFixture]
    public class DVDManagerTests
    {
        private DVDManager dvdManager;

        [Test]
        public void CanNotGetDVDsExceptionThrown()
        {
            var dvdRepository = new NotImplementedMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.GetAllDVDs();
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotGetBorrowersExceptionThrown()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new NotImplementedMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.GetAllBorrowers();
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotGetDVDInvalidId()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.GetDVD(99999);
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotGetDVDNegativeId()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.GetDVD(-20);
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotGetDVDExceptionThrown()
        {
            var dvdRepository = new NotImplementedMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.GetDVD(1);
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotGetBorrowerInvalidId()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.GetBorrower(99999);
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotGetBorrowerNegativeId()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.GetBorrower(-44);
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotGetBorrowerExceptionThrown()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new NotImplementedMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.GetBorrower(1);
            Assert.IsNull(result);
        }

        [Test]
        public void CanAddDVD()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            DVD dvd = new DVD
            {
                DVDId = 3,
                Title = "Animal Farm",
                ReleaseDate = new DateTime(2014, 01, 01),
                MPAARating = "R",
                Studio= "a",
                DirectorsName="person",
                ActorsName="other person",
                UserRating= "ok",
                UserNotes= "pigs are harsh",
                Available= true
            };
            var result = dvdManager.AddDVD(dvd);
            Assert.IsNotNull(result);
        }

        [Test]
        public void CanNotAddDVDExceptionThrown()
        {
            var dvdRepository = new NotImplementedMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            DVD dvd = new DVD
            {
                DVDId = 3,
                Title = "Animal Farm",
                ReleaseDate = new DateTime(2014, 01, 01),
                MPAARating = "R",
                Studio = "a",
                DirectorsName = "person",
                ActorsName = "other person",
                UserRating = "ok",
                UserNotes = "pigs are harsh",
                Available = true
            };
            var result = dvdManager.AddDVD(dvd);
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotAddReleaseDateTooEarly()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            DVD dvd = new DVD
            {
                DVDId = 3,
                Title = "Animal Farm",
                ReleaseDate = new DateTime(1905, 01, 01),
                MPAARating = "R",
                Studio = "a",
                DirectorsName = "person",
                ActorsName = "other person",
                UserRating = "ok",
                UserNotes = "pigs are harsh",
                Available = true
            };
            var result = dvdManager.AddDVD(dvd);
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotAddDVDMissingTitle()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            DVD dvd = new DVD
            {
                DVDId = 3,
                Title = "",
                ReleaseDate = new DateTime(1994, 01, 01),
                MPAARating = "R",
                Studio = "a",
                DirectorsName = "person",
                ActorsName = "other person",
                UserRating = "ok",
                UserNotes = "pigs are harsh",
                Available = true
            };
            var result = dvdManager.AddDVD(dvd);
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotAddBorrowerWithoutName()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);

            Borrower borrower = new Borrower { BorrowerId = 4, Name = "" };
            var result = dvdManager.AddBorrower(borrower);
            Assert.IsNull(result);
        }

        [Test]
        public void CanNotDeleteDVDNegativeID()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.RemoveDVD(-1);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanNotDeleteDVDDoesNotExist()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.RemoveDVD(99999);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanNotLoanBorrowerHasDVDAlready()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.BorrowDVD(1, 2);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanNotLoanDVDIsAlreadyOut()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.BorrowDVD(2, 1);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanNotLoanDVDDoesNotExist()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.BorrowDVD(2, 99999);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanNotLoanExceptionThrown()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new NotImplementedMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.BorrowDVD(2,2);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanNotReturnDVDDoNotHaveOne()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.BorrowerReturnDVD(2);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanNotReturnDVDExceptionThrown()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new NotImplementedMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            var result = dvdManager.BorrowerReturnDVD(1);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanNotEditDVDToHaveNoTitle()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            DVD dvd = new DVD
            {
                DVDId = 3,
                Title = "",
                ReleaseDate = new DateTime(1994, 01, 01),
                MPAARating = "R",
                Studio = "a",
                DirectorsName = "person",
                ActorsName = "other person",
                UserRating = "ok",
                UserNotes = "pigs are harsh",
                Available = true
            };
            var result = dvdManager.EditDVD(dvd);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanNotEditTooEarlyReleaseDate()
        {
            var dvdRepository = new WorkingMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            DVD dvd = new DVD
            {
                DVDId = 3,
                Title = "Animal Farm",
                ReleaseDate = new DateTime(1905, 01, 01),
                MPAARating = "R",
                Studio = "a",
                DirectorsName = "person",
                ActorsName = "other person",
                UserRating = "ok",
                UserNotes = "pigs are harsh",
                Available = true
            };
            var result = dvdManager.EditDVD(dvd);
            Assert.IsFalse(result);
        }

        [Test]
        public void CanNotEditException()
        {
            var dvdRepository = new NotImplementedMockDVDRepository();
            var borrowerRepository = new WorkingMockBorrowerRepository();
            dvdManager = new DVDManager(dvdRepository, borrowerRepository);
            DVD dvd = new DVD
            {
                DVDId = 3,
                Title = "Animal Farm",
                ReleaseDate = new DateTime(2014, 01, 01),
                MPAARating = "R",
                Studio = "a",
                DirectorsName = "person",
                ActorsName = "other person",
                UserRating = "ok",
                UserNotes = "pigs are harsh",
                Available = true
            };
            var result = dvdManager.EditDVD(dvd);
            Assert.IsFalse(result);
        }
    }
}
