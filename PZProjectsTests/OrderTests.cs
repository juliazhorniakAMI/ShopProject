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
    public class OrderTests
    {
        private IOrderService _orderService;
        private Mock<IOrderRepository> mockRepoWrapper;
        private List<OrderDTO> _orderList;
        private OrderDTO order;

        [SetUp]
        public void Setup()
        {

            mockRepoWrapper = new Mock<IOrderRepository>();
            _orderList = new List<OrderDTO>() {
                new OrderDTO() {  CustomerId= 1,DateOfCreation = DateTime.Now},
                new OrderDTO() {  CustomerId= 2,DateOfCreation = DateTime.Now},
            };
            order = new OrderDTO() {  CustomerId = 2, DateOfCreation = DateTime.Now };
            _orderService = new OrderService(mockRepoWrapper.Object);
        }

        [Test]
        public void GetOrders_ReturnsList_AreEqual()
        {
            //Arrange
            mockRepoWrapper
                .Setup(p => p.GetAllOrders())
                .Returns(_orderList);

            //Act
            List<OrderDTO> list = _orderService.GetAllOrders();

            //Assert
            Assert.AreEqual(_orderList, list);
        }

        [Test]
        public void CreateOrder_ReturnsObjects_AreEqual()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.AddOrder(It.IsAny<OrderDTO>()))
               .Callback<OrderDTO>(n => _orderList.Add(n));

            //Act
            _orderService.AddOrder(order);

            //Assert
            Assert.AreEqual(_orderList[_orderList.Count - 1], order);


        }

        [Test]
        public void UpdateOrder_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.UpdateOrder(It.IsAny<OrderDTO>()))
                 .Returns(true);

            //Act
            bool result = _orderService.UpdateOrder(order);

            //Assert
            Assert.IsTrue(result);


        }
        [Test]
        public void DeleteOrder_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.DeleteOrder(It.IsAny<int>()))
            .Returns(true);

            //Act
            bool result = _orderService.DeleteOrder(1);

            //Assert
            Assert.IsTrue(result);


        }
    }
}

