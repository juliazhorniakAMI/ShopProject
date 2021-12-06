using CursovaApp.Models;
using PZProject.BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
   public class MainViewModel:ViewModelBase
    {
        public IServiceWrapper _servicewrapper;
        public CustomerDTO customer { get; set; }
      
        public MainViewModel(CustomerDTO _customer,IServiceWrapper servicewrapper)
        {
            customer = _customer;
            _servicewrapper = servicewrapper;
            UpdateViewCommand = new UpdateViewCommand(this);      
        }
        private ViewModelBase _selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value;
            OnPropertyChanged(nameof(SelectedViewModel));              
            }
        }
        public ICommand UpdateViewCommand { get; set; }
        public Action AuthFailure { get; set; }


    }
}
