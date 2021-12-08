using CursovaApp.Models;

using PZProject.BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public interface ICloseable
    {
        Action Close { get; set; }
    }
    public class LoginViewModel:ICloseable
    {
        public IServiceWrapper _servicewrapper;
        public Customer logModel { get; set; } 
        public LoginViewModel(IServiceWrapper servicewrapper)
        {
          
            _servicewrapper = servicewrapper;
            logModel = new Customer();
            LoginCommand = new LoginCommand(this);
            CancelCommand = new LoginCommand(this);
        }
        public CustomerDTO Login() {
  
            
                if (_servicewrapper.custService.CheckIfCustomerExists(logModel.Mail, logModel.Pass))
                {
                    CustomerDTO c = _servicewrapper.custService.FindCustomer(logModel.Mail, logModel.Pass);
                    if (c.Role.FullName == "buyer")
                    {
                        return c;
                    }
                }
            return null;
        }
        public Action AuthSuccess { get; set; }
        public Action AuthFailure { get; set; }
        public ICommand LoginCommand { get;  set; }
        public ICommand CancelCommand { get;  set; }
        public Action Close { get; set; }
    }
}
