using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVDCollection.Models
{
    public class BorrowerVM
    {
        public Borrower Borrower { get; set; }
        public List<SelectListItem> DVDItems { get; set; }

        public BorrowerVM()
        {
            DVDItems = new List<SelectListItem>();
            Borrower = new Borrower();
        }

        public void SetDVDItems(IEnumerable<DVD> dvds)
        {
            foreach(var dvd in dvds)
            {
                DVDItems.Add(new SelectListItem()
                {
                    Value = dvd.DVDId.ToString(),
                    Text = dvd.Title
                });
            }
        }
    }
}