using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Policy
    {       
        public Category Category { get; set; }
        [Required(ErrorMessage ="Please enter a Policy Title.")]
        public string PolicyTitle { get; set; }
        [Required(ErrorMessage = "Please enter some content")]
        public string PolicyContent { get; set; }
        public int PolicyId { get; set; }
    }
}
