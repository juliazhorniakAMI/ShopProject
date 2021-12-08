using CursovaApp.Models;
using PZProject.BLL.Services;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
   public class OrderViewModel:ViewModelBase
    {
   
     
       public CustomerDTO customer { get; set; }

        public OrderDetails order { get; set; }
        private IServiceWrapper servicewrapper;
       public OrderViewModel(IServiceWrapper _servicewrapper, CustomerDTO _customer)
        {
            order = new OrderDetails();
            customer = _customer;
            servicewrapper = _servicewrapper;
            GetAll();
        }
        public string path
        {
            get
            {
                return $"First Name:  {customer.FirstName}\n\n" +
                    $"Last Name:  {customer.LastName}                 Role: {customer.Role.FullName}";
            }   
        }
        public void GetAll()
        {
            order.OrderDetailsList = new ObservableCollection<OrderDetails>();
            servicewrapper.orderDetailsService.GetAllOrdersDetailsByCustomerId(customer.Id).ForEach(x => order.OrderDetailsList.Add(new OrderDetails()
            {
                OrderId = x.OrderId,
                Category = servicewrapper.catService.GetCategoryById(x.Product.CategoryId).FullName,
                Product = x.Product.FullName,
                Price = x.Product.Price,
                Quantity = x.Quantity,
                Total = x.TotalSum,
                Date = x.Order.DateOfCreation

            }));
         
        }
    }
}
