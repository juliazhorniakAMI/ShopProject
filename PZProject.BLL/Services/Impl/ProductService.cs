using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.DAL.IRepositories;
using CursovaApp.Models;

namespace CursovaApp.BLL.Services.Abstract
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _Repository;

        public ProductService(IProductRepository Repository)
        {
            _Repository = Repository;
        }

        public bool AddProduct(ProductDTO product)
        {
            return _Repository.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _Repository.DeleteProduct(id);
        }
        public List<ProductDTO> FilterProducts(List<ProductDTO> sortedProducts, string name)
        {
            return _Repository.FilterProducts(sortedProducts, name);
        }
        public List<ProductDTO> GetAllProducts() {

            return _Repository.GetAllProducts();
        }
        public List<ProductDTO> GetAllProductsByCategory(CategoryDTO category)
        {
            return _Repository.GetAllProductsByCategory(category);
        }

        public ProductDTO GetProduct(string prodName)
        {
            return _Repository.GetProduct(prodName);
        }

        public ProductDTO GetProductById(int id)
        {
            return _Repository.GetProductById(id);
        }

        public List<ProductDTO> SortProducts(List<ProductDTO> sortedProducts)
        {
            return _Repository.SortProducts(sortedProducts);
        }

        public bool UpdateProduct(ProductDTO product)
        {
            return _Repository.UpdateProduct(product);
        }
    }
}
