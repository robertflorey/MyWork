using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();

        Category AddCategory(string categoryName);

        Category GetCategory(int categoryID);

        //void DeleteCategory(int categoryID);
    }
}
