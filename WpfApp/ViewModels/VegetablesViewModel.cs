using CursovaApp.Models;
using PZProject.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
   public class VegetablesViewModel:ViewModelBase
    {

        private string _searchText;
        private IServiceWrapper _servicewrapper;
        public ICommand SortedList { get; set; }
        public Product Product { get; set; }
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
       public VegetablesViewModel(IServiceWrapper servicewrapper)
        {
            Product = new Product();
            _servicewrapper = servicewrapper;
            SortedList = new SortedCommand(Product, _servicewrapper);
            GetAll();
        }
        public void GetAll()
        {
            Product.ProductsDTO = new List<ProductDTO>();
            _servicewrapper.prodService.GetAllProductsByCategory(_servicewrapper.catService.GetCategory("Vegetables")).ForEach(data => Product.ProductsDTO.Add(new ProductDTO()
            {
                Id = data.Id,
                FullName = data.FullName,
                Price = data.Price
            }));
        }
    }
}
