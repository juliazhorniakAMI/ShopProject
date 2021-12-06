using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.Models;

namespace CursovaApp.BLL.Services.Abstract
{
    public interface IProductService
    {

        List<ProductDTO> GetAllProductsByCategory(CategoryDTO category);
        bool AddProduct(ProductDTO product);
        List<ProductDTO> FilterProducts(List<ProductDTO> sortedProducts, string name);
        List<ProductDTO> SortProducts(List<ProductDTO> sortedProducts);
        bool UpdateProduct(ProductDTO product);
        ProductDTO GetProductById(int id);
        public List<ProductDTO> GetAllProducts();
        ProductDTO GetProduct(string prodName);
        bool DeleteProduct(int id);
    }
}
