using CursovaApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.DAL.IRepositories;

namespace CursovaApp.BLL.Services.Abstract
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _Repository;

        public OrderService(IOrderRepository Repository)
        {
            _Repository = Repository;
        }

        public bool AddOrder(OrderDTO order)
        {
            return _Repository.AddOrder(order);
        }
      
        public bool DeleteOrder(int id)
        {
            return _Repository.DeleteOrder(id);
        }

        public List<OrderDTO> GetAllOrders()
        {
            return _Repository.GetAllOrders();
        }

        public OrderDTO GetOrderById(int id)
        {
            return _Repository.GetOrderById(id);
        }
        public OrderDTO GetOrderByDate(DateTime date)
        {
            return _Repository.GetOrderByDate(date);
        }

        public bool UpdateOrder(OrderDTO order)
        {
            return _Repository.UpdateOrder(order);
        }
    }
}
