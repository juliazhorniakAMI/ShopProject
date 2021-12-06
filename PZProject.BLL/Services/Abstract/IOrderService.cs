using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.Models;

namespace CursovaApp.BLL.Services.Abstract
{
    public interface IOrderService
    {
        List<OrderDTO> GetAllOrders();
        bool AddOrder(OrderDTO order);
        OrderDTO GetOrderById(int id);
        bool UpdateOrder(OrderDTO order);
        OrderDTO GetOrderByDate(DateTime date);
        bool DeleteOrder(int id);
    }
}
