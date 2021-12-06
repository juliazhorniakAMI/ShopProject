using System;
using System.Collections.Generic;
using CursovaApp.DAL.IRepositories;

using System.Text;
using PZProject.BLL.Services.Abstract;
using CursovaApp.Models;

namespace PZProject.BLL.Services.Impl
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _catRepository;

        public CategoryService(ICategoryRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public bool AddCategory(CategoryDTO category)
        {
            return _catRepository.AddCategory(category);
        }

        public bool DeleteCategory(int id)
        {
            return _catRepository.DeleteCategory(id);
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return _catRepository.GetAllCategories();
        }

        public CategoryDTO GetCategory(string category)
        {
            return _catRepository.GetCategory(category);
        }
        public CategoryDTO GetCategoryById(int categoryId) {

            return _catRepository.GetCategoryById(categoryId);

        }
        public bool UpdateCategory(CategoryDTO category)
        {
            return _catRepository.UpdateCategory(category);
        }
    }




}
