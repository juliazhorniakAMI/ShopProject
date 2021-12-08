
using CursovaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using WpfApp.ViewModels;

namespace WpfApp.Models
{
    public partial class Category : ViewModelBase
    {
        private int _id;
        private string _fullName;
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
        private ObservableCollection<CategoryDTO> _categories;
        public ObservableCollection<CategoryDTO> CategoriesDTO
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
                OnPropertyChanged("CategoriesDTO");
            }
        }

    }
}
