using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CursovaApp.Models;
using PZProject.DAL.Models;

namespace CursovaApp.DAL.IRepositories
{
    public interface IOrderDetailsRepository : IGenericKeyRepository<int, OrderDetail>
    {
        List<OrderDetailDTO> GetAllOrdersDetails();
        List<OrderDetailDTO> GetAllOrdersDetailsByOrderId(int id);
        OrderDetailDTO GetOrderItemById(int orderItemId);

        bool UpdateOrderItemById(int orderItemId, OrderDetailDTO updatedItem);

        bool DeleteOrderItemById(int orderItemId);
        bool AddOrderDetail(OrderDetailDTO orderdetail);
        bool UpdateOrderItemByQuantity(int custid,string product, int quantity, double sum);
      
         bool UpdateTotalSum(List<OrderDetailDTO> list, double sum);
        List<OrderDetailDTO> GetAllOrdersDetailsByCustomerId(int custId);
        OrderDetailDTO GetOrderItemByCustomerIdProduct(int id, string product);



    }
}
