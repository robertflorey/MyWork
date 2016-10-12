using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.BLL.Tests.Mocks
{
    public class MissingInfoMockPolicyRepository : IPolicyRepository
    {
        public Policy AddPolicy(Policy policy)
        {
            
            return null;
        }

        public bool DeletePolicy(int policyId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Policy> GetPolicies()
        {
            throw new NotImplementedException();
        }

        public Policy GetPolicy(int policyId)
        {
            throw new NotImplementedException();
        }
    }
}
