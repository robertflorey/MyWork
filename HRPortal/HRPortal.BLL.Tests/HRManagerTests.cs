using HRPortal.BLL;
using HRPortal.BLL.Tests.Mocks;
using HRPortal.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.BLL.Tests
{
    [TestFixture]
    public class HRManagerTests
    {
        private HRManager hrmanager;

        [Test]
        public void CanGetPolicy()
        {
            var policyRepository = new MockPolicyRepository();
            var categoryRepository = new MockCategoryRepository();
            var applicantRepository = new MockApplicantRepository();
            hrmanager = new HRManager(policyRepository, categoryRepository, applicantRepository);
            var policy = hrmanager.GetPolicy(1);
            Assert.IsNotNull(policy);
        }

        [Test]
        public void InvalidPolicy()
        {
            var policyRepository = new MockPolicyRepository();
            var categoryRepository = new MockCategoryRepository();
            var applicantRepository = new MockApplicantRepository();
            hrmanager = new HRManager(policyRepository, categoryRepository, applicantRepository);
            var policy = hrmanager.GetPolicy(0);
            Assert.IsNull(policy);
        }

        [Test]
        public void AddPolicySuccess()
        {
            var policyRepository = new MockPolicyRepository();
            var categoryRepository = new MockCategoryRepository();
            var applicantRepository = new MockApplicantRepository();
            hrmanager = new HRManager(policyRepository, categoryRepository, applicantRepository);
            var policyA = new Policy
            { PolicyTitle = "titled", PolicyContent = "something", Category = new Category {CategoryId=1, CategoryName="Some Category" } };
            Assert.IsNotNull(hrmanager.AddPolicy(policyA));
        }

        [Test]
        public void CanNotAddPolicyDuplicate()
        {
            var policyRepository = new ExistingTitleMockPolicyRepository();
            var categoryRepository = new MockCategoryRepository();
            var applicantRepository = new MockApplicantRepository();
            hrmanager = new HRManager(policyRepository, categoryRepository, applicantRepository);
            var policyA = new Policy
            { PolicyTitle = "Some Policy", PolicyContent = "something", Category = new Category { CategoryId = 1, CategoryName = "Some Category" } };
            Assert.IsNull(hrmanager.AddPolicy(policyA));
        }

        [Test]
        public void MissingTitleCanNotAddPolicy()
        {
            var policyRepository = new MissingInfoMockPolicyRepository();
            var categoryRepository = new MockCategoryRepository();
            var applicantRepository = new MockApplicantRepository();
            hrmanager = new HRManager(policyRepository, categoryRepository, applicantRepository);
            var policyA = new Policy
            { PolicyTitle = "", PolicyContent = "something", Category = new Category { CategoryId = 1, CategoryName = "Some Category" } };
            var result= hrmanager.AddPolicy(policyA);
            Assert.IsNull(result);
        }

        [Test]
        public void MissingContentCanNotAddPolicy()
        {
            var policyRepository = new MissingInfoMockPolicyRepository();
            var categoryRepository = new MockCategoryRepository();
            var applicantRepository = new MockApplicantRepository();
            hrmanager = new HRManager(policyRepository, categoryRepository, applicantRepository);
            var policyA = new Policy
            { PolicyTitle = "Other Policy", PolicyContent = "", Category = new Category { CategoryId = 1, CategoryName = "Some Category" } };
            var result = hrmanager.AddPolicy(policyA);
            Assert.IsNull(result);
        }

        [Test]
        public void ThrownExceptionCanNotAddPolicy()
        {
            var policyRepository = new AddPolicyExceptionMockPolicyRepository();
            var categoryRepository = new MockCategoryRepository();
            var applicantRepository = new MockApplicantRepository();
            hrmanager = new HRManager(policyRepository, categoryRepository, applicantRepository);
            Policy policy = new Policy
            { PolicyTitle = "policy", PolicyContent = "content", Category = new Category { CategoryId = 1, CategoryName = "category" } };
            var result = hrmanager.AddPolicy(policy);
            Assert.IsNull(result);
        }

        [Test]
        public void CanAddCategory()
        {
            var policyRepository = new MockPolicyRepository();
            var categoryRepository = new MockCategoryRepository();
            var applicantRepository = new MockApplicantRepository();
            hrmanager = new HRManager(policyRepository, categoryRepository, applicantRepository);
            Category category = new Category();
            category.CategoryName = "a category";
            var result = hrmanager.AddCategory(category.CategoryName);
            Assert.IsNotNull(result);
        }

        [Test]
        public void MissingTitleCanNotAddCategory()
        {
            var policyRepository = new MockPolicyRepository();
            var categoryRepository = new MockCategoryRepository();
            var applicantRepository = new MockApplicantRepository();
            hrmanager = new HRManager(policyRepository, categoryRepository, applicantRepository);
            Category category = new Category();
            var result = hrmanager.AddCategory(category.CategoryName);
            Assert.IsNull(result);
        }

        [Test]
        public void ExceptionThrownCanNotAddCategory()
        {
            var policyRepository = new MockPolicyRepository();
            var categoryRepository = new ExceptionThrownInAddMockCategoryRepository();
            var applicantRepository = new MockApplicantRepository();
            hrmanager = new HRManager(policyRepository, categoryRepository, applicantRepository);
            Category category = new Category();
            category.CategoryName = "a category";
            var result = hrmanager.AddCategory(category.CategoryName);
            Assert.IsNull(result);
        }
    }
}
