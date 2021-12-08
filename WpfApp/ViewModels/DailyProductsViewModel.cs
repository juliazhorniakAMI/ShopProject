using CursovaApp.BLL.Services.Abstract;
using CursovaApp.Models;
using PZProject.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class DailyProductsViewModel : ViewModelBase
    {
        private string _searchText;
        private IServiceWrapper _servicewrapper;
        public Product Product { get; set; }
        public ICommand SortedList { get; set; }     
        public CustomerDTO Customer { get; set; }
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;

                OnPropertyChanged("SearchText");
                OnPropertyChanged("FilteredList");
            }
        }
        public ICommand FilteredList { get { return new FilterCommand(Product, _servicewrapper, SearchText); } set { } }
        public DailyProductsViewModel(IServiceWrapper servicewrapper)
        {
            Product = new Product();
            Customer = new CustomerDTO();
            _servicewrapper = servicewrapper;
            GetAll();
            SortedList = new SortedCommand(Product, _servicewrapper);        
        }
        public void GetAll()
        {
            Product.ProductsDTO = new List<ProductDTO>();
            _servicewrapper.prodService.GetAllProductsByCategory(_servicewrapper.catService.GetCategory("Daily products")).ForEach(data => Product.ProductsDTO.Add(new ProductDTO()
            {
                Id = data.Id,
                FullName = data.FullName,
                Price = data.Price
            }));
        }
     
    }
}
