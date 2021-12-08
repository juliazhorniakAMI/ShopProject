using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CursovaApp.Models;
using PZProject.DAL.Models;

namespace CursovaApp.DAL.IRepositories
{
   public interface ICategoryRepository : IGenericKeyRepository<int, Category>
    {
        List<CategoryDTO> GetAllCategories();
        bool AddCategory(CategoryDTO category);
        bool UpdateCategory(CategoryDTO category);
        CategoryDTO GetCategoryById(int categoryId);
        CategoryDTO GetCategory(string category);
        bool DeleteCategory(int id);

   }
}
