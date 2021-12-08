
using CursovaApp.Models;
using PZProject.BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.Models;

namespace WpfApp.Commands
{
   public class FilterCommand:ICommand
    {

        private Product product;
        private IServiceWrapper _servicewrapper;
        private string name;
     
        public FilterCommand(Product _product, IServiceWrapper servicewrapper,string _name)
        {
            this._servicewrapper = servicewrapper;
            this.product = _product;
            this.name = _name;

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
            if(parameter.ToString()== "DailyFilter" || parameter.ToString() == "FruitsFilter"|| parameter.ToString() == "Filter")
            {        
                List<ProductDTO> filteredlist = new List<ProductDTO>();
                filteredlist = _servicewrapper.prodService.FilterProducts(product.ProductsDTO, name);
                product.ProductsDTO = new List<ProductDTO>();
                filteredlist.ForEach(data => product.ProductsDTO.Add(new ProductDTO()
                {
                    Id = data.Id,
                    FullName = data.FullName,
                    Price = data.Price
                }));
              
                }
            }
        }
    }

