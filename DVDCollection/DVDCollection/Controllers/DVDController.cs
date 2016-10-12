using DVDCollection.BLL;
using DVDCollection.Models;
using DVDCollection.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVDCollection.Controllers
{
    public class DVDController : Controller
    {
        private readonly DVDManager dvdManager;

        public DVDController() : this(new DVDManager(new DbDVDRepository(), new DbBorrowerRepository())) { }

        public DVDController( DVDManager dvdManager)
        {
            this.dvdManager = dvdManager;
        }

        [HttpGet]
        public ActionResult ViewDVDs()
        {
            var model = dvdManager.GetAllDVDs();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddDVD()
        {
            return View(new DVD());
        }

        [HttpPost]
        public ActionResult AddDVD(DVD dvd)
        {
            if (ModelState.IsValid)
            {
                dvdManager.AddDVD(dvd);
                return RedirectToAction("ViewDVDs");
            }
            return View(dvd);
        }

        [HttpGet]
        public ActionResult ViewDVD(int dvdId)
        {
            var dvd = dvdManager.GetDVD(dvdId);
            return View(dvd);
        }

        [HttpGet]
        public ActionResult EditDVD(int dvdId)
        {
            DVDVM dvdVM = new DVDVM();
            dvdVM.DVD = dvdManager.GetDVD(dvdId);
            return View(dvdVM);
        }

        [HttpPost]
        public ActionResult EditDVD(DVDVM dvdvm)
        {
            dvdManager.EditDVD(dvdvm.DVD);
            return RedirectToAction("ViewDVDs");
        }

        [HttpGet]
        public ActionResult LoanDVD(DVD dvd)
        {
            DVDVM viewModel = new DVDVM();
            viewModel.DVD = dvd;
            viewModel.SetBorrowerItems(dvdManager.GetAllBorrowers());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult LoanDVD(DVDVM dvdVM)
        {
            
            dvdManager.BorrowDVD(dvdVM.DVD.BorrowerId.Value, dvdVM.DVD.DVDId);
            dvdManager.LendDVD(dvdVM.DVD.DVDId, dvdVM.DVD.BorrowerId.Value);
            return RedirectToAction("ViewDVDs");
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var model = dvdManager.GetDVDByTitle(search);
            return View(model);
        }
    }
}