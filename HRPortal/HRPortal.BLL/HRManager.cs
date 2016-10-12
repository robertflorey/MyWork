using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.BLL
{
    public class HRManager
    {
        private IPolicyRepository policyRepository;
        private ICategoryRepository categoryRepository;
        private IApplicantRepository applicantRepository;

        public HRManager(IPolicyRepository policyRepository, ICategoryRepository categoryRepository, IApplicantRepository applicantRepository)
        {
            this.policyRepository = policyRepository;
            this.categoryRepository = categoryRepository;
            this.applicantRepository = applicantRepository;
        }

        public IEnumerable<Policy> GetPolicies()
        {
            return policyRepository.GetPolicies();
        }

        public Policy AddPolicy(Policy policy)
        {
            if(policy.PolicyTitle==null || policy.PolicyTitle=="")
            {
                return null;
            }
            else if(policy.PolicyContent==null || policy.PolicyContent=="")
            {
                return null;
            }
            else if(policy.Category.CategoryName==null || policy.Category.CategoryName=="")
            {
                return null;
            }
            foreach (Policy item in GetPolicies())
            {
                if (item.PolicyTitle==policy.PolicyTitle)
                {
                    return null;
                }
            }
            try
            {
                return policyRepository.AddPolicy(policy);
            }
            catch
            {
                return null;
            }
        }

        public Policy GetPolicy(int policyId)
        {
            return policyRepository.GetPolicy(policyId);
        }

        public bool DeletePolicy(int policyId)
        {
            foreach (Policy policy in GetPolicies())
            {
                if (policy.PolicyId == policyId)
                {
                    policyRepository.DeletePolicy(policyId);
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public Category AddCategory(string categoryName)
        {
            if (categoryName == null || categoryName=="")
            {
                return null;
            }
            foreach(Category category in GetAllCategories())
            {
                if (categoryName==category.CategoryName)
                {
                    return null;
                }
            }
            try
            {
                return categoryRepository.AddCategory(categoryName);
            }
            catch
            {
                return null;
            }
        }

        public Category GetCategory(int categoryId)
        {
            return categoryRepository.GetCategory(categoryId);
        }

        //public void DeleteCategory(int categoryId)
        //{
        //    categoryRepository.DeleteCategory(categoryId);
        //}

        public IEnumerable<Applicant> GetApplicants()
        {
            return applicantRepository.GetApplicants();
        }

        public Applicant Apply(Applicant applicant)
        {
            return applicantRepository.Apply(applicant);
        }
    }
}
