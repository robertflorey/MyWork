using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using HRPortal.BLL;
using HRPortal.Models;
using HRPortal.Data;


namespace HRPortal.Controllers
{
    public class HRController : Controller
    {
        private readonly HRManager hrManager;

        public HRController() : this(new HRManager(new PolicyRepository(), new CategoryRepository(), new ApplicantRepository())) { }

        public HRController(HRManager hrManager)
        {
            this.hrManager = hrManager;
        }

        [HttpGet]
        public ActionResult ManageCategories()
        {
            var model = hrManager.GetAllCategories();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult AddCategory(Category category, bool redirect)
        {
            if (ModelState.IsValid)
            {
                if (hrManager.AddCategory(category.CategoryName) == null)
                {
                    return View("SorryCategoryExists", category);
                }
                if (redirect)
                {
                    return RedirectToAction("ManageCategories");
                }
                else
                {
                    return RedirectToAction("AddPolicy");
                }
            }
            else
            {
                return View(category);
            }
        }

        //[HttpGet]
        //public ActionResult DeleteCategory(int categoryId)
        //{
        //    hRManager = new HRManager(repoA, repoB);
        //    Category category = hRManager.GetCategory(categoryId);
        //    return View(category);
        //}

        //[HttpPost]
        //public ActionResult DeleteCategory(Category category)
        //{
        //    hRManager = new HRManager(repoA, repoB);
        //    hRManager.DeleteCategory(category.CategoryId);
        //    return RedirectToAction("ManageCategories");
        //}

        [HttpGet]
        public ActionResult ManagePolicies()
        {
            var policies = hrManager.GetPolicies();
            var model = policies.GroupBy(p => p.Category.CategoryName);
            return View(model);
        }

        [HttpGet]
        public ActionResult AddPolicy()
        {
            var viewModel = new PolicyVM();
            viewModel.SetCategoryItems(hrManager.GetAllCategories());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddPolicy(PolicyVM policyVM)
        {
            if (ModelState.IsValid)
            {
                if (hrManager.GetCategory(policyVM.Policy.Category.CategoryId) != null)
                {
                    policyVM.Policy.Category = hrManager.GetCategory(policyVM.Policy.Category.CategoryId);
                }
                else
                {
                    hrManager.AddCategory(policyVM.Policy.Category.CategoryName);
                }
                if (hrManager.AddPolicy(policyVM.Policy)==null)
                {
                    return View("Sorry", policyVM);
                }
                return RedirectToAction("ManagePolicies");
            }
            else
            {
                return View(policyVM);
            }

        }

        [HttpGet]
        public ActionResult DeletePolicy(int policyId)
        {
            var policy = hrManager.GetPolicy(policyId);
            return View(policy);
        }

        [HttpPost]
        public ActionResult DeletePolicy(Policy policy)
        {
            hrManager.DeletePolicy(policy.PolicyId);
            return RedirectToAction("ManagePolicies");

        }
    }
}