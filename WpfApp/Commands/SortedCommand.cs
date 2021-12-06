using CursovaApp.Models;
using PZProject.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class SortedCommand : ICommand
    {

        private MainViewModel viewModel;
        private Product product;
        private IServiceWrapper _servicewrapper;


        public event EventHandler CanExecuteChanged;
        public SortedCommand(Product _product, IServiceWrapper servicewrapper)
        {
            this._servicewrapper = servicewrapper;
            this.product = _product;

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (parameter.ToString() != null) {

                product.ProductsDTO = new List<ProductDTO>();
                if (parameter.ToString() == "DailySorted")
                {       
                    _servicewrapper.prodService.GetAllProductsByCategory(_servicewrapper.catService.GetCategory("Daily products")).OrderBy(x => x.FullName).ToList().ForEach(data => product.ProductsDTO.Add(new ProductDTO()
                    {
                        Id = data.Id,
                        FullName = data.FullName,
                        Price = data.Price
                    }));
                }
                else if (parameter.ToString() == "FruitsSorted")
                {
                    _servicewrapper.prodService.GetAllProductsByCategory(_servicewrapper.catService.GetCategory("Fruits")).OrderBy(x => x.FullName).ToList().ForEach(data => product.ProductsDTO.Add(new ProductDTO()
                    {
                        Id = data.Id,
                        FullName = data.FullName,
                        Price = data.Price
                    }));
                }
                else
                {
                    _servicewrapper.prodService.GetAllProductsByCategory(_servicewrapper.catService.GetCategory("Vegetables")).OrderBy(x => x.FullName).ToList().ForEach(data => product.ProductsDTO.Add(new ProductDTO()
                    {
                        Id = data.Id,
                        FullName = data.FullName,
                        Price = data.Price
                    }));
                  
                }
            }

        }
    }
   
}
