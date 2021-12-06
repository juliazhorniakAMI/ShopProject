using CursovaApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    internal class LoginCommand : ICommand
    {
      
        LoginViewModel viewModel;

        public LoginCommand(LoginViewModel _viewModel)
        {
            this.viewModel = _viewModel;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
          
            return true;
        }
        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Login")
            {
                if (viewModel.Login() != null)
                {
                    viewModel.AuthSuccess?.Invoke();

                }
                else
                {
                    viewModel.AuthFailure?.Invoke();

                }
            }
            else {
                this.viewModel.Close();
            
            }       

        }
    }
}
