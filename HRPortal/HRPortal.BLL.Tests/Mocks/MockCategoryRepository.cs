using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.BLL.Tests.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public List<Category> categories = new List<Category>
        {
            new Category {CategoryId=1,CategoryName="some category" }
        };

        public Category AddCategory(string categoryName)
        {
            Category category = new Category();
            category.CategoryName = categoryName;
            category.CategoryId = GetAllCategories().Max(c => c.CategoryId) + 1;
            return category;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categories;
        }

        public Category GetCategory(int categoryID)
        {
            throw new NotImplementedException();
        }
    }
}
