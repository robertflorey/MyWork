using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.Models
{
    public class DVD
    {
        public int DVDId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string MPAARating { get; set; }
        [Required]
        public string Studio { get; set; }
        [Required]
        public string DirectorsName { get; set; }
        [Required]
        public string ActorsName { get; set; }
        [Required]
        public string UserRating { get; set; }
        [Required]
        public string UserNotes { get; set; }
        public bool Available { get; set; }
        public int? BorrowerId { get; set; }
    }
}
