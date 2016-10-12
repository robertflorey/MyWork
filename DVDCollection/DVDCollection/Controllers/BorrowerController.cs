using DVDCollection.BLL;
using DVDCollection.Data;
using DVDCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVDCollection.Controllers
{
    public class BorrowerController : Controller
    {
        private readonly DVDManager dvdManager;

        public BorrowerController() : this(new DVDManager(new DbDVDRepository(), new DbBorrowerRepository())) { }

        public BorrowerController(DVDManager dvdManager)
        {
            this.dvdManager = dvdManager;
        }
        // GET: Borrower
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Borrowers()
        {
            var model = dvdManager.GetAllBorrowers();
            return View(model);
        }

        [HttpGet]
        public ActionResult ViewBorrower(int borrowerId)
        {
            Borrower borrower = new Borrower();
            borrower = dvdManager.GetBorrower(borrowerId);
            return View(borrower);
        }

        [HttpPost]
        public ActionResult ViewBorrower(Borrower borrower)
        {
            int dvdId = borrower.DVDId.Value;
            dvdManager.ReturnDVD(dvdId);
            dvdManager.BorrowerReturnDVD(borrower.BorrowerId);
            return RedirectToAction("ViewDVDs", "DVD");
        }

        [HttpGet]
        public ActionResult AddBorrower()
        {
            return View(new Borrower());
        }

        [HttpPost]
        public ActionResult AddBorrower(Borrower borrower)
        {
            dvdManager.AddBorrower(borrower);
            return RedirectToAction("Borrowers");
        }
    }
}