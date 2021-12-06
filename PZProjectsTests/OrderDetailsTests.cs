using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;
using CursovaApp.BLL.Services.Abstract;
using CursovaApp.DAL.IRepositories;
using CursovaApp.Models;
using Moq;
using NUnit.Framework;

namespace PZProjectsTests
{
    public class OrderDetailsTests
    {
        private IOrderDetailsService _orderService;
        private Mock<IOrderDetailsRepository> mockRepoWrapper;
        private List<OrderDetailDTO> _orderList;
        private OrderDetailDTO order;

        [SetUp]
        public void Setup()
        {

            mockRepoWrapper = new Mock<IOrderDetailsRepository>();
            _orderList = new List<OrderDetailDTO>() {
                new OrderDetailDTO() { ProductId= 1,OrderId =1,TotalSum = 10,Quantity = 1},
                new OrderDetailDTO() {  ProductId= 2,OrderId =1,TotalSum = 10,Quantity = 1},
            };
            order = new OrderDetailDTO() { ProductId = 2, OrderId = 1, TotalSum = 10, Quantity = 1 };
            _orderService = new OrderDetailsService(mockRepoWrapper.Object);
        }

        [Test]
        public void GetOrderDetails_ReturnsList_AreEqual()
        {
            //Arrange
            mockRepoWrapper
                .Setup(p => p.GetAllOrdersDetails())
                .Returns(_orderList);

            //Act
            List<OrderDetailDTO> list = _orderService.GetAllOrdersDetails();

            //Assert
            Assert.AreEqual(_orderList, list);
        }

        [Test]
        public void CreateOrderDetail_ReturnsObjects_AreEqual()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.AddOrderDetail(It.IsAny<OrderDetailDTO>()))
               .Callback<OrderDetailDTO>(n => _orderList.Add(n));

            //Act
            _orderService.AddOrderDetail(order);

            //Assert
            Assert.AreEqual(_orderList[_orderList.Count - 1], order);


        }

        [Test]
        public void UpdateOrderDetail_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.UpdateOrderItemById(It.IsAny<int>(), It.IsAny<OrderDetailDTO>()))
                 .Returns(true);

            //Act
            bool result = _orderService.UpdateOrderItemById(1, order);

            //Assert
            Assert.IsTrue(result);


        }
        [Test]
        public void DeleteOrderDetail_Returns_IsTrue()
        {
            //Arrange

            mockRepoWrapper
           .Setup(x => x.DeleteOrderItemById(It.IsAny<int>()))
            .Returns(true);

            //Act
            bool result = _orderService.DeleteOrderItemById(1);

            //Assert
            Assert.IsTrue(result);


        }
    }
}
