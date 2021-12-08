
using CursovaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WpfApp.ViewModels;

namespace WpfApp.Models
{
   public class OrderDetails: ViewModelBase,IDataErrorInfo
    {
      
        private string _category;
        private string _product;
        private double _price;
        private DateTime _date;
        private double _sum;
        private int _orderid;
        private int _quantity;
        public bool _isEnabled;
        private ObservableCollection<OrderDetails> _orders;
        public Dictionary<string, string> ErrorCollection { get; set; } = new Dictionary<string, string>();

        [Required]
        [MinLength(1)]
        [MaxLength(10)]
        public int Quantity {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
              
            }
        }
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");

            }
        }
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }
        public double Price
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
        public int OrderId
        {
            get
            {
                return _orderid;
            }
            set
            {
                _orderid = value;
                OnPropertyChanged("OrderId");
            }
        }
        public double Total {
            get
            {
                return _sum;
            }
            set
            {
                _sum = value;
                OnPropertyChanged("Total");
            }
        }
        public string Category {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged("Category");
            }
        }
        public string Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                OnPropertyChanged("Product");
            }
        }
        public ObservableCollection<OrderDetails> OrderDetailsList
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                OnPropertyChanged("OrderDetailsList");
            }
        }
        public string Error {
            get { return null; }
        }
        public string this[string columnName]
        {
            get
            {       
               string error = null;
                switch (columnName)
                {
                    case "Quantity":
                        if (string.IsNullOrEmpty(columnName)){
                            error = "object cannot be null";
                        }
                       else if ((Quantity < 1) || (Quantity > 10))
                        {
                            error = "Must be between 1-10";
                           
                        }
                        break;                 
                }
                if (ErrorCollection.ContainsKey(columnName))
                    ErrorCollection[columnName] = error;
                else if (error != null) {
                    ErrorCollection.Add(columnName, error);
                }
                OnPropertyChanged("ErrorCollection");
                if (error != null)
                {
                    IsEnabled = false;
                }
                else {
                    IsEnabled = true;
                }
                return error;
            }
        }
    }
}
