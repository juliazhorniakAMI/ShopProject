using CursovaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using WpfApp.ViewModels;

namespace WpfApp.Models
{
    public partial class Product : ViewModelBase
    {
        private int _id;
        private string _fullName;
        private int _categoryid;
        private int _price;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public string FullName
        {

            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public int CategoryId
        {
            get
            {
                return _categoryid;
            }
            set
            {
                _categoryid = value;
                OnPropertyChanged("CategoryId");
            }

        }
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        private List<ProductDTO> _products;
        public List<ProductDTO> ProductsDTO
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                OnPropertyChanged("ProductsDTO");
            }
        }
     
    }
}
