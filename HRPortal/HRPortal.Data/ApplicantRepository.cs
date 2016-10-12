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
    public class ApplicantRepository : IApplicantRepository
    {
        public IEnumerable<Applicant> GetApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();
            Applicant applicant;
            string directoryPath = @"C:\Users\apprentice\HRPortal\Applicants\";
            foreach (string file in Directory.EnumerateFiles(directoryPath))
            {
                using (var stream = File.OpenRead(file))
                {
                    var serializer = new DataContractJsonSerializer(typeof(Applicant));
                    applicant = (Applicant)serializer.ReadObject(stream);
                };
                applicants.Add(applicant);
            }
            return applicants;
        }

        public Applicant Apply(Applicant applicant)
        {
            var applicants = GetApplicants();
            int fileCount = Directory.GetFiles(@"C:\Users\apprentice\HRPortal\Applicants\").Length;
            if (fileCount == 0)
            {
                applicant.ApplicantId = 1;
            }
            else
            {
                applicant.ApplicantId = applicants.Max(p => p.ApplicantId) + 1;
            }
            string path = string.Format(@"C:\Users\apprentice\HRPortal\Applicants\{0}.json", applicant.ApplicantId);
            
            using (var stream = File.OpenWrite(path))
            {
                var serializer = new DataContractJsonSerializer(typeof(Applicant));
                serializer.WriteObject(stream, applicant);
            }
            return applicant;
        }
    }
}
