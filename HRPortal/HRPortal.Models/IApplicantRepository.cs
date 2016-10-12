using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> GetApplicants();
        Applicant Apply(Applicant applicant);
    }
}
