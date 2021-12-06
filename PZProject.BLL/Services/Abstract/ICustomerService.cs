using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.Models;

namespace CursovaApp.BLL.Services.Abstract
{
    public interface ICustomerService
    {
        bool CheckIfCustomerExists(string email, string password);
        List<CustomerDTO> GetAllCustomers();
        bool UpdateCustomer(CustomerDTO user);
        CustomerDTO FindCustomer(string email, string password);
        bool DeleteCustomer(int id);
        bool AddCustomer(CustomerDTO user);
        CustomerDTO GetCustomerById(int id);
        string GetHashStringSHA256(string str,string salt);
      
    }
}
