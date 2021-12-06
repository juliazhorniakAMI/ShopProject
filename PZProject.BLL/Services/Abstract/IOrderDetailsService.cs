using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.Models;

namespace CursovaApp.BLL.Services.Abstract
{
   public interface IOrderDetailsService
    {
        List<OrderDetailDTO> GetAllOrdersDetails();
        List<OrderDetailDTO> GetAllOrdersDetailsByOrderId(int id);
        OrderDetailDTO GetOrderItemById(int orderItemId);
        bool UpdateOrderItemById(int orderItemId, OrderDetailDTO updatedItem);
        public List<OrderDetailDTO> GetAllOrdersDetailsByCustomerId(int custId);
        bool DeleteOrderItemById(int orderItemId);
        bool AddOrderDetail(OrderDetailDTO orderdetail);
        bool UpdateOrderItemByQuantity(int custid, string product, int quantity, double sum);
        bool UpdateTotalSum(List<OrderDetailDTO> list, double sum);
        OrderDetailDTO GetOrderItemByCustomerIdProduct(int id, string product);

    }
}
