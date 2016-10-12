using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.BLL.Tests.Mocks
{
    public class ExistingTitleMockPolicyRepository : IPolicyRepository
    {
        public Policy AddPolicy(Policy policy)
        {
            throw new NotImplementedException();
        }

        public bool DeletePolicy(int policyId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Policy> GetPolicies()
        {
            List<Policy> policies = new List<Policy>
            { new Policy {PolicyTitle="Some Policy"} };

            return policies;
        }

        public Policy GetPolicy(int policyId)
        {
            throw new NotImplementedException();
        }
    }
}
