using CursovaApp.Models;
using PZProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursovaApp.DAL.IRepositories
{
    public interface IOrderRepository : IGenericKeyRepository<int, Order>
    {
        List<OrderDTO> GetAllOrders();
        bool AddOrder(OrderDTO order);
        OrderDTO GetOrderById(int id);
        bool UpdateOrder(OrderDTO order);
        OrderDTO GetOrderByDate(DateTime date);
        bool DeleteOrder(int id);

    }
}

