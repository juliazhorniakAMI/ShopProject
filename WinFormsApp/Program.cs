using AutoMapper;
using CursovaApp.BLL.Services.Abstract;
using CursovaApp.DAL.IRepositories;
using CursovaApp.DAL.Repositories;
using CursovaApp.Repositories;
using PZProject.BLL.Services;
using PZProject.BLL.Services.Abstract;
using PZProject.BLL.Services.Impl;
using PZProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace WinFormsApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static UnityContainer Container;
     
        [STAThread]
        static void Main()
        {
            ConfigureUnity();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(Container.Resolve<Form1>());
          
        }
        private static void ConfigureUnity()
        {
            MapperConfiguration config = new MapperConfiguration(

                cfg =>
                {

                    cfg.AddMaps(typeof(CategoryRep).Assembly);

                }
                );
            Container = new UnityContainer();
            Container.RegisterInstance<IMapper>(config.CreateMapper());
            Container.RegisterType<IRoleService, RoleService>();
            Container.RegisterType<ICustomerService, CustomerService>();
            Container.RegisterType<ICategoryService, CategoryService>();
            Container.RegisterType<IOrderService, OrderService>();
            Container.RegisterType<IProductService, ProductService>();
            Container.RegisterType<IOrderDetailsService,OrderDetailsService>();
            Container.RegisterType<IRoleRepository, RoleRepository>();
            Container.RegisterType<ICategoryRepository, CategoryRep>();
            Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Container.RegisterType<IOrderDetailsRepository, OrderDetailRepository>();
            Container.RegisterType<IOrderRepository, OrderRepository>();
            Container.RegisterType<IProductRepository, ProductRepository>();
            Container.RegisterType<IServiceWrapper, ServiceWrapper>();
        }
    }
}
