using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CursovaApp.DAL.IRepositories;
using CursovaApp.DAL.Repositories;
using CursovaApp.Models;
using Microsoft.EntityFrameworkCore;
using PZProject.DAL.Models;

namespace CursovaApp.DAL.Repositories
{
    public class OrderRepository : GenericKeyRepository<int, Order, ShopPZContext>, IOrderRepository
    {
        private readonly IMapper mapper;
        public OrderRepository(ShopPZContext context, IMapper _mapper) : base(context)
        {
            mapper = _mapper;
        }

        public List<OrderDTO> GetAllOrders()
        {

            return mapper.Map<List<Order>, List<OrderDTO>>(Context.Orders.Select(x=>x).ToList());
          
        }

      
        public bool AddOrder(OrderDTO o)
        {
          Order order = mapper.Map<OrderDTO, Order>(o);

            return Add(order);
        }

        public OrderDTO GetOrderById(int id)
        {
            Order o= Context.Orders.FirstOrDefault(x => x.Id == id);
            return mapper.Map<Order, OrderDTO>(o);
       
        }
        public OrderDTO GetOrderByDate(DateTime date)
        {
            Order o = Context.Orders.FirstOrDefault(x => x.DateOfCreation == date);
            return mapper.Map<Order, OrderDTO>(o);
          
        }
        public bool UpdateOrder(OrderDTO order)
        {
            var existingOrder = Context.Orders.First(x => x.Id == order.Id);

            if (existingOrder == null) return false;

            existingOrder.CustomerId = order.CustomerId;
            existingOrder.DateOfCreation = order.DateOfCreation;
            return Update(existingOrder);
        }


        public bool DeleteOrder(int id)
        {
            var product = GetById(id);
            return Delete(product);
        }
    }
}
