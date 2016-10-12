using HRPortal.BLL;
using HRPortal.Data;
using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly HRManager hrManager;

        public HomeController() : this(new HRManager(new PolicyRepository(), new CategoryRepository(), new ApplicantRepository())) { }

        public HomeController(HRManager hrManager)
        {
            this.hrManager = hrManager;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Apply()
        {
            var viewModel = new Applicant();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Apply(Applicant model)
        {
            if (ModelState.IsValid)
            {
                hrManager.Apply(model);
                return RedirectToAction("ThankYou", model);
            }
            else
            {
                return View(model);
            }
        }


        [HttpGet]
        public ActionResult ThankYou(Applicant model)
        {
            return View(model);
        }
    }
}