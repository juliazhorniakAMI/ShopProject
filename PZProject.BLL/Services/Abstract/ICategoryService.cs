using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.Models;

namespace PZProject.BLL.Services.Abstract
{
   public interface ICategoryService
    {
        List<CategoryDTO> GetAllCategories();
         bool AddCategory(CategoryDTO category);
         bool UpdateCategory(CategoryDTO category);
         CategoryDTO GetCategory(string category);
        bool DeleteCategory(int id);
        CategoryDTO GetCategoryById(int categoryId);
    }
}
