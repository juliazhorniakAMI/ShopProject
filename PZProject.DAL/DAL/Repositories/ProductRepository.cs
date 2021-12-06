using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CursovaApp.DAL.IRepositories;
using CursovaApp.DAL.Repositories;
using CursovaApp.Models;
using Microsoft.EntityFrameworkCore;
using PZProject.DAL.Models;

namespace CursovaApp.DAL.Repositories
{
    public class ProductRepository : GenericKeyRepository<int, Product, ShopPZContext>, IProductRepository
    {
        private readonly IMapper mapper;
        public ProductRepository(ShopPZContext context, IMapper _mapper) : base(context)
        {
            mapper = _mapper;
        }
        public List<ProductDTO> GetAllProducts()
        {
            var query = (from p in Context.Products
                         select p).ToList();
            return mapper.Map<List<Product>, List<ProductDTO>>(query);

        }
        public List<ProductDTO> GetAllProductsByCategory(CategoryDTO category)
        {

            var query= mapper.Map<List<Product>, List<ProductDTO>>(Context.Products.Where(x => x.CategoryId == category.Id).ToList());
            return query;
        }

        public ProductDTO GetProduct(string prodName)
        {
            return mapper.Map<Product,ProductDTO>(Context.Products.FirstOrDefault(x => x.FullName == prodName));

        }
        public ProductDTO GetProductById(int id)
        {
         
            return mapper.Map<Product, ProductDTO>(Context.Products.FirstOrDefault(x => x.Id == id));

        }
        public bool AddProduct(ProductDTO product)
        {
           Product p= mapper.Map<ProductDTO, Product>(product);
            return Add(p);
        }


        public bool UpdateProduct(ProductDTO product)
        {
            var existingProd = Context.Products.First(x => x.Id == product.Id);

            if (existingProd == null) return false;

            existingProd.CategoryId = product.CategoryId;
            existingProd.FullName = product.FullName;
            existingProd.Price = product.Price;

           return Update(existingProd);
        }


        public List<ProductDTO> SortProducts(List<ProductDTO> sortedProducts)
        {

            return sortedProducts.OrderBy(x => x.FullName).ToList();
        }
        public List<ProductDTO> FilterProducts(List<ProductDTO> sortedProducts, string name)
        {

            return sortedProducts.Where(s => s.FullName.StartsWith(name)).ToList();
        }
        public int GetProductId(string name)
        {

            Product p = Context.Products.FirstOrDefault(x => x.FullName == name);

            return p.Id;
        }

        public bool DeleteProduct(int id)
        {
            var product = GetById(id);
            return Delete(product);
        }
    }
}
