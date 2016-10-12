using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRPortal.BLL;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HRPortal.Models
{
    public class PolicyVM
    {
        public Policy Policy { get; set; }
        public List<SelectListItem> CategoryItems { get; set; }

        public PolicyVM()
        {
            CategoryItems = new List<SelectListItem>();
            Policy = new Policy();
        }

        public void SetCategoryItems(IEnumerable<Category> categories)
        {
            foreach (var category in categories)
            {
                CategoryItems.Add(new SelectListItem()
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.CategoryName
                });
            }
            CategoryItems.Insert(0, new SelectListItem() { Value = "0", Text = "Please Select" });
        }
        
    }
}