using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.ViewModels;


namespace WpfApp.Commands
{
   public class UpdateViewCommand:ICommand
    {

        private MainViewModel viewModel;

        public event EventHandler CanExecuteChanged;
        public UpdateViewCommand(MainViewModel _viewModel)
        {
            this.viewModel = _viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {

            if (parameter.ToString() == "Daily")
            {

                viewModel.SelectedViewModel = new DailyProductsViewModel(viewModel._servicewrapper);
            }
            else if (parameter.ToString() == "Fructs")
            {
                viewModel.SelectedViewModel = new FruitsViewModel(viewModel._servicewrapper);
            }
            else if (parameter.ToString() == "Vegetables")
            {
                viewModel.SelectedViewModel = new VegetablesViewModel(viewModel._servicewrapper);
            }
            else if (parameter.ToString() == "Orders")
            {

                viewModel.SelectedViewModel = new OrderViewModel(viewModel._servicewrapper, viewModel.customer);
            }
            else if (parameter.ToString() == "Cart")
            {

                viewModel.SelectedViewModel = new CartViewModel(viewModel._servicewrapper, viewModel.customer);
            }
            else {
                viewModel.AuthFailure?.Invoke();
            }
        }
    }
}
