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
    public class EmployeeController : Controller
    {
        private readonly HRManager hrManager;

        public EmployeeController() : this(new HRManager(new PolicyRepository(), new CategoryRepository(), new ApplicantRepository())) { }

        public EmployeeController(HRManager hrManager)
        {
            this.hrManager = hrManager;
        }

        public ActionResult EmployeeHome()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult ViewPolicies()
        {
            var policies = hrManager.GetPolicies();
            var model = policies.GroupBy(p => p.Category.CategoryName);
            return View(model);
        }

        [HttpGet]
        public ActionResult ViewPolicy(int policyId)
        {
            var policy = hrManager.GetPolicy(policyId);
            return View(policy);
        }        
    }
}