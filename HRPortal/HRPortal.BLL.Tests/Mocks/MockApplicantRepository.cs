using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.BLL.Tests.Mocks
{
    public class MockApplicantRepository : IApplicantRepository
    {
        public Applicant Apply(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Applicant> GetApplicants()
        {
            throw new NotImplementedException();
        }
    }
}
