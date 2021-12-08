using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.BLL.Services.Abstract;
using CursovaApp.DAL.IRepositories;
using CursovaApp.Models;
using Moq;
using NUnit.Framework;
using PZProject.BLL.Services.Abstract;
using PZProject.BLL.Services.Impl;

namespace PZProjectsTests
{
    public class CategoryTests
    {
        private ICategoryService _categService;
        private Mock<ICategoryRepository> mockRepoWrapper;
        private List<CategoryDTO> _categoryList;
        private CategoryDTO category;

        [SetUp]
        public void Setup()
        {

            mockRepoWrapper = new Mock<ICategoryRepository>();
            _categoryList = new List<CategoryDTO>() {
                new CategoryDTO() { FullName="fruits"},
                new CategoryDTO() { FullName="vegetables"},
            };
            category = new CategoryDTO() { FullName = "bakery" };
            _categService = new CategoryService(mockRepoWrapper.Object);
        }

        [Test]
        public void GetCategories_ReturnsList_AreEqual()
        {
            //Arrange
            mockRepoWrapper
                .Setup(p => p.GetAllCategories())
                .Returns(_categoryList);

            //Act
            List<CategoryDTO> list = _categService.GetAllCategories();

            //Assert
            Assert.AreEqual(_categoryList, list);
        }

        [Test]
        public void CreateCategory_ReturnsObjects_AreEqual()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.AddCategory(It.IsAny<CategoryDTO>()))
               .Callback<CategoryDTO>(n => _categoryList.Add(n));

            //Act
            _categService.AddCategory(category);

            //Assert
            Assert.AreEqual(_categoryList[_categoryList.Count - 1], category);


        }

        [Test]
        public void UpdateCategory_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.UpdateCategory(It.IsAny<CategoryDTO>()))
                 .Returns(true);

            //Act
            bool result = _categService.UpdateCategory(category);

            //Assert
            Assert.IsTrue(result);


        }
        [Test]
        public void DeleteCategory_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.DeleteCategory(It.IsAny<int>()))
            .Returns(true);

            //Act
            bool result = _categService.DeleteCategory(1);

            //Assert
            Assert.IsTrue(result);


        }

    }
}
