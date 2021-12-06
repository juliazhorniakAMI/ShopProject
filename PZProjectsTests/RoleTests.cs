using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.BLL.Services.Abstract;
using CursovaApp.DAL.IRepositories;
using CursovaApp.DAL.Repositories;
using CursovaApp.Models;
using Moq;
using NUnit.Framework;

namespace PZProjectsTests
{
    public class RoleTests
    {
        private IRoleService _roleService;
        private Mock<IRoleRepository> mockRepoWrapper;
        private List<RoleDTO> _roleList;
        private RoleDTO customer;
        [SetUp]
        public void Setup()
        {

            mockRepoWrapper = new Mock<IRoleRepository>();
            _roleList = new List<RoleDTO>() {
                new RoleDTO() {  FullName="admin"},
                new RoleDTO() { FullName="buyer"},
            };
            customer = new RoleDTO() {FullName = "buyer" };
            _roleService = new RoleService(mockRepoWrapper.Object);
        }

        [Test]
        public void GetRoles_ReturnsList_AreEqual()
        {
            //Arrange
            mockRepoWrapper
                .Setup(p => p.GetAllRoles())
                .Returns(_roleList);

            //Act
            List<RoleDTO> list = _roleService.GetAllRoles();

            //Assert
            Assert.AreEqual(_roleList, list);
        }

        [Test]
        public void CreateRole_ReturnsObjects_AreEqual()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.AddRole(It.IsAny<RoleDTO>()))
               .Callback<RoleDTO>(n => _roleList.Add(n));

            //Act
            _roleService.AddRole(customer);

            //Assert
            Assert.AreEqual(_roleList[_roleList.Count - 1], customer);


        }

        [Test]
        public void UpdateRole_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.UpdateRole(It.IsAny<RoleDTO>()))
                 .Returns(true);

            //Act
            bool result = _roleService.UpdateRole(customer);

            //Assert
            Assert.IsTrue(result);


        }
        [Test]
        public void DeleteRole_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.DeleteRole(It.IsAny<int>()))
            .Returns(true);

            //Act
            bool result = _roleService.DeleteRole(1);

            //Assert
            Assert.IsTrue(result);


        }



    }
}
