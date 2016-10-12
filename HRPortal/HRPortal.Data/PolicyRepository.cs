using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Data
{
    public class PolicyRepository : IPolicyRepository
    {
        public IEnumerable<Policy> GetPolicies()
        {
            List <Policy> policies = new List<Policy>();
            Policy policy;
            string directoryPath = @"C:\Users\apprentice\HRPortal\Policies\";
                foreach(string file in Directory.EnumerateFiles(directoryPath))
                {
                    using (var stream = File.OpenRead(file))
                    {
                        var serializer = new DataContractJsonSerializer(typeof(Policy));
                        policy = (Policy)serializer.ReadObject(stream);
                    };
                    policies.Add(policy);
                }
                return policies;
        }

        public Policy AddPolicy(Policy policy)
        {
            var policies = GetPolicies();
            int fileCount = Directory.GetFiles(@"C:\Users\apprentice\HRPortal\Policies\").Length;
            if (fileCount == 0)
            {
                policy.PolicyId = 1;
            }
            else
            {
                policy.PolicyId = policies.Max(p => p.PolicyId) + 1;
            }
            string path = string.Format(@"C:\Users\apprentice\HRPortal\Policies\{0}.json",policy.PolicyId);
                using (var stream = File.OpenWrite(path))
                {
                    var serializer = new DataContractJsonSerializer(typeof(Policy));
                    serializer.WriteObject(stream, policy);
                }
                return policy;
            
        }

        public Policy GetPolicy(int policyId)
        {
            var policies = GetPolicies().ToList();
            return policies.FirstOrDefault(p => p.PolicyId == policyId);
        }

        public bool DeletePolicy(int policyId)
        {
            string path = string.Format(@"C:\Users\apprentice\HRPortal\Policies\{0}.json", policyId);
            File.Delete(path);
            return true;
        }
    }
}
