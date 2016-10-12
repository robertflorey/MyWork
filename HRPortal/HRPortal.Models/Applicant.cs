using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRPortal.Models
{
    public class Applicant
    {        
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Reason { get; set; }
        public int ApplicantId { get; set; }
    }
}