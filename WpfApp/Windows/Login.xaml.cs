using AutoMapper;
using CursovaApp.BLL.Services.Abstract;
using CursovaApp.DAL.IRepositories;
using CursovaApp.DAL.Repositories;
using CursovaApp.Repositories;
using PZProject.BLL.Services;
using PZProject.BLL.Services.Abstract;
using PZProject.BLL.Services.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;
using WpfApp.ViewModels;

namespace WpfApp.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {  
        
        public static UnityContainer Container;   
        public Login()
        {    
            ConfigureUnity();
            InitializeComponent();
            DataContext = Container.Resolve<LoginViewModel>();
            Loaded += Load_Login;
        }

        private void Load_Login(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseable cb) {
                cb.Close += () =>
                {
                    this.Close();
                };                 
            }
            if (DataContext is LoginViewModel lvm) {
                lvm.AuthSuccess += () =>
                {
                    MainWindow m = new MainWindow(lvm.Login(), lvm._servicewrapper);
                    m.Show();
                    this.Close();
                };
                lvm.AuthFailure += () =>
                {
                    MessageBox.Show("Wrong mail or password");

                };
            }
        }
       private void Pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null) {


                ((dynamic)this.DataContext).logModel.Pass = ((PasswordBox)sender).Password;
            }
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
            Container.RegisterType<IOrderDetailsService, OrderDetailsService>();
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
