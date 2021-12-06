using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.BLL.Services.Abstract;
using CursovaApp.DAL.IRepositories;
using CursovaApp.Models;
using Moq;
using NUnit.Framework;

namespace PZProjectsTests
{
    public class ProductTests
    {
        private IProductService _productService;
        private Mock<IProductRepository> mockRepoWrapper;
        private List<ProductDTO> _productList;
        private ProductDTO product;
        private CategoryDTO category = new CategoryDTO() { Id = 1, FullName = "fruits" };
        [SetUp]
        public void Setup()
        {

            mockRepoWrapper = new Mock<IProductRepository>();
            _productList = new List<ProductDTO>() {
                new ProductDTO() { FullName="apple",CategoryId = 1,Price = 10},
                new ProductDTO() {  FullName="lemon",CategoryId = 1,Price = 10},
            };
            product = new ProductDTO() { FullName = "melon", CategoryId = 3, Price = 20 };
            _productService = new ProductService(mockRepoWrapper.Object);
        }

        [Test]
        public void GetProducts_ReturnsList_AreEqual()
        {
            //Arrange
            mockRepoWrapper
                .Setup(p => p.GetAllProductsByCategory(It.IsAny<CategoryDTO>()))
                .Returns(_productList);

            //Act
            List<ProductDTO> list = _productService.GetAllProductsByCategory(category);

            //Assert
            Assert.AreEqual(_productList, list);
        }

        [Test]
        public void CreateProduct_ReturnsObjects_AreEqual()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.AddProduct(It.IsAny<ProductDTO>()))
               .Callback<ProductDTO>(n => _productList.Add(n));

            //Act
            _productService.AddProduct(product);

            //Assert
            Assert.AreEqual(_productList[_productList.Count - 1], product);


        }

        [Test]
        public void UpdateProduct_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.UpdateProduct(It.IsAny<ProductDTO>()))
                 .Returns(true);

            //Act
            bool result = _productService.UpdateProduct(product);

            //Assert
            Assert.IsTrue(result);


        }
        [Test]
        public void DeleteProduct_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.DeleteProduct(It.IsAny<int>()))
            .Returns(true);

            //Act
            bool result = _productService.DeleteProduct(1);

            //Assert
            Assert.IsTrue(result);


        }
    }
}
