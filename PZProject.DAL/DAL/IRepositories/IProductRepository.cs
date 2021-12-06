using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CursovaApp.Models;
using PZProject.DAL.Models;

namespace CursovaApp.DAL.IRepositories
{
   public interface IProductRepository : IGenericKeyRepository<int, Product>
    {

       List<ProductDTO> GetAllProductsByCategory(CategoryDTO category);
       bool AddProduct(ProductDTO product);
       List<ProductDTO> FilterProducts(List<ProductDTO> sortedProducts, string name);
       List<ProductDTO> SortProducts(List<ProductDTO> sortedProducts);
       bool UpdateProduct(ProductDTO product);
       ProductDTO GetProductById(int id);
       ProductDTO GetProduct(string prodName);
        public List<ProductDTO> GetAllProducts();
       bool DeleteProduct(int id);
    }
}

