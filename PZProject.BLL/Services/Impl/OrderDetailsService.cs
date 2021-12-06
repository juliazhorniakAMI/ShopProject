using CursovaApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.DAL.IRepositories;

namespace CursovaApp.BLL.Services.Abstract
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _Repository;

        public OrderDetailsService(IOrderDetailsRepository Repository)
        {
            _Repository = Repository;
        }

        public bool AddOrderDetail(OrderDetailDTO orderdetail)
        {
            return _Repository.AddOrderDetail(orderdetail);
        }

        public bool DeleteOrderItemById(int orderItemId)
        {
            return _Repository.DeleteOrderItemById(orderItemId);
        }

        public List<OrderDetailDTO> GetAllOrdersDetailsByCustomerId(int custId)
        {
            return _Repository.GetAllOrdersDetailsByCustomerId(custId);
        }
        public List<OrderDetailDTO> GetAllOrdersDetails()
        {
            return _Repository.GetAllOrdersDetails();
        }
        public List<OrderDetailDTO> GetAllOrdersDetailsByOrderId(int id)
        {
            return _Repository.GetAllOrdersDetailsByOrderId(id);
        }

        public OrderDetailDTO GetOrderItemByCustomerIdProduct(int id, string product)
        {
            return _Repository.GetOrderItemByCustomerIdProduct(id, product);
        }

        public OrderDetailDTO GetOrderItemById(int orderItemId)
        {
            return _Repository.GetOrderItemById(orderItemId);
        }

        public bool UpdateOrderItemById(int orderItemId, OrderDetailDTO updatedItem)
        {
            return _Repository.UpdateOrderItemById(orderItemId, updatedItem);
        }

        public bool UpdateOrderItemByQuantity(int custid, string product, int quantity, double sum)
        {
            return _Repository.UpdateOrderItemByQuantity(custid, product, quantity, sum);
        }

        public bool UpdateTotalSum(List<OrderDetailDTO> list, double sum)
        {
            return _Repository.UpdateTotalSum(list, sum);
        }
    }
}
