using CursovaApp.BLL.Services.Abstract;
using PZProject.BLL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PZProject.BLL.Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        public ICategoryService _catService;
        public ICustomerService _custService;
        public IOrderDetailsService _orderDetailsService;
        public IOrderService _orderService;
        public IProductService _prodService;
        public IRoleService _roleService;
        public ServiceWrapper(ICategoryService catService,
        ICustomerService custService,
        IOrderDetailsService orderDetailsService,
        IOrderService orderService,
        IProductService prodService,
        IRoleService roleService)
        {
            _catService = catService;
            _custService = custService;
            _orderDetailsService = orderDetailsService;
            _orderService = orderService;
            _prodService = prodService;
            _roleService = roleService;
        }
   
        public ICategoryService catService { get => _catService; }
        public ICustomerService custService { get => _custService; }
        public IOrderDetailsService orderDetailsService { get => _orderDetailsService; }
        public IOrderService orderService { get => _orderService; }
        public IProductService prodService { get => _prodService; }
        public IRoleService roleService { get => _roleService; }
    }
}
