using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CursovaApp.DAL.IRepositories;
using CursovaApp.Models;
using Microsoft.EntityFrameworkCore;
using PZProject.DAL.Models;
using AutoMapper;

namespace CursovaApp.DAL.Repositories
{
    public class CategoryRep : GenericKeyRepository<int, Category, ShopPZContext>, ICategoryRepository
    {
        private readonly IMapper mapper;
        public CategoryRep(ShopPZContext context,IMapper _mapper) : base(context)
        {
            mapper = _mapper;
        }
        public List<CategoryDTO> GetAllCategories()
        {
            var query = (from p in Context.Categories
                         select p).ToList() ;
          return  mapper.Map<List<Category>, List<CategoryDTO>>(query);
          
        }
        public CategoryDTO GetCategory(string category)
        {
            Category c = Context.Categories.FirstOrDefault(x => x.FullName == category);
            return mapper.Map<Category,CategoryDTO>(c);
         

        }
        public CategoryDTO GetCategoryById(int categoryId)
        {
            Category c = Context.Categories.FirstOrDefault(x => x.Id == categoryId);
            return mapper.Map<Category, CategoryDTO>(c);
          

        }
        public bool AddCategory(CategoryDTO category)
        {
            Category c = mapper.Map<CategoryDTO,Category>(category);
            return Add(c);
        }

        public bool UpdateCategory(CategoryDTO category)
        {
            var existingCat = Context.Categories.First(x => x.Id == category.Id);

            if (existingCat == null) return false;

            existingCat.FullName = category.FullName;

            return Update(existingCat);
        }

        public bool DeleteCategory(int id)
        {
            var category = GetById(id);
            return Delete(category);
        }
    }
}
