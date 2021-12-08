using CursovaApp.Models;
using PZProject.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
	class CartViewModel : ViewModelBase
	{ 
		public CustomerDTO customer { get; set; }
		public ProductDTO product { get; set; }
		public OrderDetails order { get; set; }
		public Product Product { get; set; }
        public List<string> prodList
		{
			get
			{
				return servicewrapper.prodService.GetAllProducts().Select(x =>x.FullName).ToList();
			}
			set { }
		}
		private IServiceWrapper servicewrapper;
		private ICommand _saveCommand;
		private ICommand _resetCommand;
		private ICommand _confirmCommand;
		private ICommand _deleteCommand;
		private object _selectedItem; 
        public object SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				_selectedItem = value;
				OnPropertyChanged("SelectedItem");
			}
		}
		public ICommand ResetCommand
		{
			get
			{
				if (_resetCommand == null)
					_resetCommand = new RelayCommand(param => ResetData(), null);

				return _resetCommand;
			}
		}
		public ICommand ConfirmCommand
		{
			get
			{
				if (_confirmCommand == null)
					_confirmCommand = new RelayCommand(param => ConfirmData(), null);

				return _confirmCommand;
			}
		}
		public ICommand SaveCommand
		{
			get
			{
				if (_saveCommand == null)
					_saveCommand = new RelayCommand(param => SaveData(), null);

				return _saveCommand;
			}
		}
		public ICommand DeleteCommand
		{
			get
			{
				if (_deleteCommand == null)
					_deleteCommand = new RelayCommand(param => DeleteProduct(),null);

				return _deleteCommand;
			}
		}
		public void ResetData()
		{	
			order.Price = 0;
			order.Quantity = 1;	

		}
		public CartViewModel(IServiceWrapper _servicewrapper, CustomerDTO _customer)
		{
			servicewrapper = _servicewrapper;
			order = new OrderDetails();
			prodList= servicewrapper.prodService.GetAllProducts().Select(x => x.FullName).ToList();
			order.Product = prodList[0];
			order.Total = 0;
			order.Quantity = 1;
			order.OrderDetailsList = new ObservableCollection<OrderDetails>();
			customer = _customer;		
		}
		public void DeleteProduct()
		{
			if (MessageBox.Show("Confirm delete of this product?", $"{customer.FirstName}", MessageBoxButton.YesNo)
				== MessageBoxResult.Yes)
			{
				try
				{
					OrderDetails neworder = (OrderDetails)SelectedItem;
					order.Total -= neworder.Price * neworder.Quantity;
					order.OrderDetailsList.Remove(neworder);

					MessageBox.Show("product successfully deleted.");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error occured while saving. " + ex.InnerException);
				}
			}
		}
		public void SaveData()
		{
			if (order != null)
			{
				product = servicewrapper.prodService.GetProduct(order.Product);
				order.Price = product.Price;

				order.OrderDetailsList.Add(new OrderDetails()
				{
					Product = order.Product,
					Price = order.Price,
					Quantity = order.Quantity,

				});
				order.Total += order.Price * order.Quantity;
				ResetData();
			}
			else {
				ResetData();
			}
		}
		public void ConfirmData()
		{
			if (order.OrderDetailsList.Count > 0)
			{
				OrderDTO o = new OrderDTO() { CustomerId = customer.Id, DateOfCreation = DateTime.Now };

				servicewrapper.orderService.AddOrder(o);
				OrderDTO newOrder = servicewrapper.orderService.GetOrderByDate(o.DateOfCreation);
				foreach (var obj in order.OrderDetailsList)
				{
					product = servicewrapper.prodService.GetProduct(obj.Product);
					OrderDetailDTO orderdetail = new OrderDetailDTO()
					{ ProductId = product.Id, OrderId = newOrder.Id, Quantity = obj.Quantity, TotalSum = order.Total };
					servicewrapper.orderDetailsService.AddOrderDetail(orderdetail);
				}
				MessageBox.Show("Your order has been added to cart");
				order.Total = 0;
				ResetData();
				order.OrderDetailsList = new ObservableCollection<OrderDetails>();
			}
			else
			{
				MessageBox.Show("you haven't added anything to cart");
			}

		}
	}
}


