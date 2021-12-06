using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.DAL.IRepositories;
using CursovaApp.Models;

namespace CursovaApp.BLL.Services.Abstract
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _custRepository;

        public CustomerService(ICustomerRepository custRepository)
        {
            _custRepository = custRepository;
        }
        public CustomerDTO GetCustomerById(int id)
        {
            return _custRepository.GetCustomerById(id);
        }

        public bool AddCustomer(CustomerDTO user)
        {
            return _custRepository.AddCustomer(user);
        }

        public bool CheckIfCustomerExists(string email, string password)
        {
            return _custRepository.CheckIfCustomerExists(email, password);
        }

        public bool DeleteCustomer(int id)
        {
            return _custRepository.DeleteCustomer(id);
        }

        public CustomerDTO FindCustomer(string email, string password)
        {
            return _custRepository.FindCustomer(email, password);
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            return _custRepository.GetAllCustomers();
        }

        public string GetHashStringSHA256(string str, string salt)
        {
            return _custRepository.GetHashStringSHA256(str,salt);
        }

        public bool UpdateCustomer(CustomerDTO user)
        {
            return _custRepository.UpdateCustomer(user);
        }
    }
}
