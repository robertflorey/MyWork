using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace HRPortal.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategories()
        {
            string directoryPath = @"C:\Users\apprentice\HRPortal\Categories\";
            Category category;
            List<Category> categories = new List<Category>();
            foreach (string file in Directory.EnumerateFiles(directoryPath))
                {
                    using (var stream = File.OpenRead(file))
                    {
                        var serializer = new DataContractJsonSerializer(typeof(Category));
                        category = (Category)serializer.ReadObject(stream);
                    };
                    categories.Add(category);
                }
                return categories;
        }

        public Category AddCategory(string categoryName)
        {
            var categories = GetAllCategories();
            Category category = new Category();
            category.CategoryName = categoryName;
            int fileCount = Directory.GetFiles(@"C:\Users\apprentice\HRPortal\Categories\").Length;
            if (fileCount == 0)
            {
                category.CategoryId = 1;
            }
            else
            {
                category.CategoryId = categories.Max(c => c.CategoryId) + 1;
            }
            string path = string.Format(@"C:\Users\apprentice\HRPortal\Categories\{0}.json", category.CategoryId);
            using (var stream = File.OpenWrite(path))
            {
                var serializer = new DataContractJsonSerializer(typeof(Category));
                serializer.WriteObject(stream, category);
            }
            return category;
        }

        public Category GetCategory(int categoryId)
        {
            var categories = GetAllCategories();
            return categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }
        //public void DeleteCategory(int categoryId)
        //{
        //    //_categories.RemoveAll(c => c.CategoryId == categoryId);
        //}
    }
}
