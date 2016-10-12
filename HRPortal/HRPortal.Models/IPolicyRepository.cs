using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public interface IPolicyRepository
    {
        IEnumerable<Policy> GetPolicies();

        Policy AddPolicy(Policy policy);

        Policy GetPolicy(int policyId);

        bool DeletePolicy(int policyId);
    }
}
