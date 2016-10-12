using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.BLL.Tests.Mocks
{
    public class ExceptionThrownInAddMockCategoryRepository : ICategoryRepository
    {
        public Category AddCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            return categories;
        }

        public Category GetCategory(int categoryID)
        {
            throw new NotImplementedException();
        }
    }
}
