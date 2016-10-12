using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVDCollection.Models
{
    public class DVDVM
    {
        public DVD DVD { get; set; }
        public List<SelectListItem> BorrowerItems { get; set; }

        public DVDVM()
        {
            BorrowerItems = new List<SelectListItem>();
            DVD = new DVD();
        }

        public void SetBorrowerItems(IEnumerable<Borrower> borrowers)
        {
            foreach (var borrower in borrowers)
            {
                BorrowerItems.Add(new SelectListItem()
                {
                    Value= borrower.BorrowerId.ToString(),
                    Text= borrower.Name
                });
                
            }
            BorrowerItems.Insert(0, new SelectListItem() { Value = "0", Text = "Choose A Borrower" });
        }
    }
}