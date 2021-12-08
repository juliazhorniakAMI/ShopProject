using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using System.Xml.Schema;
using CursovaApp.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using CursovaApp.Models;
using CursovaApp.DAL.Repositories;
using PZProject.DAL.Models;
using AutoMapper;

namespace CursovaApp.DAL.Repositories
{
    public class OrderDetailRepository : GenericKeyRepository<int, OrderDetail, ShopPZContext>, IOrderDetailsRepository
    {
        private readonly IMapper mapper;
        public OrderDetailRepository(ShopPZContext context, IMapper _mapper) : base(context)
        {
            mapper = _mapper;
        }
        public List<OrderDetailDTO> GetAllOrdersDetailsByOrderId(int id)
        {
            return mapper.Map<List<OrderDetail>, List<OrderDetailDTO>>(Context.OrderDetails.Where(x => x.OrderId == id).ToList());
         
        }
        public List<OrderDetailDTO> GetAllOrdersDetailsByCustomerId(int custId)
        {
            var query = mapper.Map<List<OrderDetail>, List<OrderDetailDTO>>(Context.OrderDetails
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Where(x => x.Order.CustomerId == custId).ToList());
            return query;
        }
        public List<OrderDetailDTO> GetAllOrdersDetails()
        {
            return mapper.Map<List<OrderDetail>, List<OrderDetailDTO>>(Context.OrderDetails
                .Include(x => x.Order)
                .Include(x => x.Product)

                .ToList());
        }
        public OrderDetailDTO GetOrderItemById(int orderItemId)
        {

            return mapper.Map<OrderDetail, OrderDetailDTO>(Context.OrderDetails
                .Where(x => x.Id == orderItemId)
                .Include(x => x.Order)
                .Include(x => x.Product)
                .FirstOrDefault());

        }
         
        public bool AddOrderDetail(OrderDetailDTO o)
        {

            OrderDetail orderdetail= mapper.Map<OrderDetailDTO, OrderDetail>(o);
            return Add(orderdetail);
        }
   
        public OrderDetailDTO GetOrderItemByCustomerIdProduct(int id, string product)
        {
            OrderDetail o= Context.OrderDetails
                .Where(x => x.Order.CustomerId == id && x.Product.FullName == product)
                .FirstOrDefault();

            return mapper.Map<OrderDetail, OrderDetailDTO>(o);
          
        }
        public bool UpdateOrderItemById(int orderItemId, OrderDetailDTO updatedItem)
        {
            var item = GetOrderItemById(orderItemId);
            OrderDetail order = GetById(item.Id);
            order.OrderId = updatedItem.OrderId;

            order.Quantity = updatedItem.Quantity;
            order.ProductId = updatedItem.ProductId;

            return Update(order);
        }
        public bool UpdateOrderItemByQuantity(int custid, string product, int quantity, double sum)
        {

            var item = GetOrderItemByCustomerIdProduct(custid, product);
          
            OrderDetail order = GetById(item.Id);

            order.Quantity = quantity;

            return Update(order);
        }
        public bool UpdateTotalSum(List<OrderDetailDTO> list, double sum)
        {

            foreach (var o in list)
            {
                OrderDetail order = GetById(o.Id);
                order.TotalSum = sum;

                return Update(order);

            }

            return true;
        }

        public bool DeleteOrderItemById(int orderItemId)
        {
            var orderItem = GetById(orderItemId);
            return Delete(orderItem);
        }

    }
}
