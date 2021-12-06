using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CursovaApp.Models;
using PZProject.DAL.Models;

namespace CursovaApp.DAL.IRepositories
{
    public interface ICustomerRepository : IGenericKeyRepository<int, Customer>
    {

        bool CheckIfCustomerExists(string email, string password);
            List<CustomerDTO> GetAllCustomers();
            bool UpdateCustomer(CustomerDTO user);
            CustomerDTO FindCustomer(string email, string password);
            bool DeleteCustomer(int id);
            bool AddCustomer(CustomerDTO user);
           string GetHashStringSHA256(string str, string salt);
            CustomerDTO GetCustomerById(int id);




    }
}
