using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.BLL.Tests.Mocks
{
    public class MockPolicyRepository : IPolicyRepository
    {

        public List<Policy> policies = new List<Policy>
        {
             new Policy
                {
                    PolicyTitle= "fake policy",
                    PolicyContent = "Some info",
                    Category = new Category{ CategoryId=1, CategoryName= "fake category"}
                },
             new Policy
                {
                    PolicyTitle= "Other Policy",
                    PolicyContent = "Other info",
                    Category = new Category{ CategoryId=1, CategoryName= "fake category"}
                },
             new Policy
                {
                    PolicyTitle= "Another policy",
                    PolicyContent = "More info",
                    Category = new Category{ CategoryId=1, CategoryName= "fake category"}
                }
        };
        public Policy policyA = new Policy
        {
            PolicyId = 1,
            PolicyTitle = "Some Policy",
            PolicyContent = "Some Content",
            Category = new Category{ CategoryId = 2, CategoryName = "Some Category" }
        };


        public Policy AddPolicy(Policy policy)
        {           
                return policy;            
        }

        public bool DeletePolicy(int policyId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Policy> GetPolicies()
        {
            return policies;
        }

        public Policy GetPolicy(int policyId)
        {           
            if (policyId == policyA.PolicyId)
            {

               return policyA;
            }
            return null;               
        }    
    }
}
