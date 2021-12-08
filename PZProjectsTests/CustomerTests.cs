using System;
using System.Collections.Generic;
using CursovaApp.BLL.Services.Abstract;
using CursovaApp.DAL.IRepositories;
using CursovaApp.Models;
using Moq;
using NUnit.Framework;

namespace PZProjectsTests
{
    public class CustomerTests
    {
        private ICustomerService _custService;
        private Mock<ICustomerRepository> mockRepoWrapper;
        private List<CustomerDTO> _custist;
        private CustomerDTO customer;
        [SetUp]
        public void Setup()
        {

            mockRepoWrapper = new Mock<ICustomerRepository>();
            _custist = new List<CustomerDTO>() {
                new CustomerDTO() { FirstName= "name1", LastName = "surname1" , Mail="mail1",Salt=new Guid(),Pass = "pass1",RoleId = 1},
                new CustomerDTO() {Id = 1, FirstName= "name2", LastName = "surname2" ,Salt=new Guid(), Mail="mail2",Pass = "pass2",RoleId = 2},
            };
            customer = new CustomerDTO() { Id = 2, FirstName = "name3", LastName = "surname3", Salt = new Guid(), Mail = "mail3", Pass = "pass3", RoleId = 2 };
            _custService = new CustomerService(mockRepoWrapper.Object);
        }

        [Test]
        public void GetCustomers_ReturnsList_AreEqual()
        {
            //Arrange
            mockRepoWrapper
                .Setup(p => p.GetAllCustomers())
                .Returns(_custist);

            //Act
            List<CustomerDTO> list = _custService.GetAllCustomers();

            //Assert
            Assert.AreEqual(_custist, list);
        }

        [Test]
        public void GetCustomerById_ReturnsCustomer_AreEqual()
        {
            //Arrange
            mockRepoWrapper
                .Setup(p => p.GetCustomerById(It.IsAny<int>()))
                .Returns(customer);

            //Act
            CustomerDTO cust = _custService.GetCustomerById(It.IsAny<int>());

            //Assert
            Assert.AreEqual(customer, cust);
        }

        [Test]
        public void FindCustomer_ReturnsObject_AreEqual()
        {
            //Arrange
            mockRepoWrapper
                .Setup(p => p.FindCustomer(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(customer);

            //Act
            CustomerDTO cust = _custService.FindCustomer(It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Assert.AreEqual(customer, cust);
        }

        [Test]
        public void CheckIfCustomerExists_ReturnsTrue_IsTrue()
        {
            //Arrange
            mockRepoWrapper
                .Setup(p => p.CheckIfCustomerExists(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            //Act
            bool result = _custService.CheckIfCustomerExists(It.IsAny<string>(), It.IsAny<string>());

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CreateCustomer_ReturnsObjects_AreEqual()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.AddCustomer(It.IsAny<CustomerDTO>()))
               .Callback<CustomerDTO>(n => _custist.Add(n));

            //Act
            _custService.AddCustomer(customer);

            //Assert
            Assert.AreEqual(_custist[_custist.Count - 1], customer);


        }

        [Test]
        public void UpdateCustomer_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.UpdateCustomer(It.IsAny<CustomerDTO>()))
                 .Returns(true);

            //Act
            bool result = _custService.UpdateCustomer(customer);

            //Assert
            Assert.IsTrue(result);


        }
        [Test]
        public void DeleteNote_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.DeleteCustomer(It.IsAny<int>()))
            .Returns(true);

            //Act
            bool result = _custService.DeleteCustomer(1);

            //Assert
            Assert.IsTrue(result);


        }
        [Test]
        public void CreateObject_Count_IsTrue()
        {
            int size = _custist.Count;
            //Arrange
            mockRepoWrapper
                .Setup(x => x.AddCustomer(It.IsAny<CustomerDTO>()))
                .Callback<CustomerDTO>(note => _custist.Add(note));

            //Act
            _custService.AddCustomer(customer);

            //Assert
            Assert.IsTrue(_custist.Count == (size + 1));

        }
        [Test]
        public void DeleteObject_Count_IsTrue()
        {
            int size = _custist.Count;
            //Arrange
            mockRepoWrapper
                .Setup(x => x.DeleteCustomer(It.IsAny<int>()))
                .Callback<int>(id => _custist.RemoveAt(id));

            //Act
            _custService.DeleteCustomer(1);

            //Assert
            Assert.IsTrue(_custist.Count == (size - 1));

        }


    }
}