using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using System.Security.Cryptography;

using CursovaApp.Models;
using CursovaApp.Repositories;
using Microsoft.EntityFrameworkCore;
using CursovaApp.DAL.Repositories;
using CursovaApp.DAL.IRepositories;
using PZProject.DAL.Models;
using AutoMapper;

namespace CursovaApp.Repositories
{
    public class CustomerRepository : GenericKeyRepository<int, Customer, ShopPZContext>, ICustomerRepository
    {
        private readonly IMapper mapper;
        public CustomerRepository(ShopPZContext context, IMapper _mapper) : base(context)
        {
            mapper = _mapper;
        }
        public bool CheckIfCustomerExists(string email, string password)
        {
            Customer customer = Context.Customers.FirstOrDefault(x => x.Mail == email);
            return Context.Customers.Any(x => x.Mail == email && x.Pass == GetHashStringSHA256(password,customer.Salt.ToString()));
        }

        public CustomerDTO GetCustomerById(int id)
        {
            return mapper.Map<Customer, CustomerDTO>(Context.Customers.FirstOrDefault(x => x.Id == id));
        
        }
        public CustomerDTO FindCustomer(string email, string password)
        {
            Customer c = Context.Customers.FirstOrDefault(x => x.Mail == email);
            Role role = Context.Roles.FirstOrDefault(x => x.Id == c.RoleId);
            c.Role = role;
            return mapper.Map<Customer, CustomerDTO>(c);
        
        }
        public List<CustomerDTO> GetAllCustomers()
        {
            var query = (from user in Context.Customers
                         select user).Include(x => x.Role).ToList();
            return mapper.Map<List<Customer>,List<CustomerDTO>>(query);
       
        }

        public bool AddCustomer(CustomerDTO c)
        {
            Customer cust = mapper.Map<CustomerDTO, Customer>(c);
            return Add(cust);
        }

        public bool UpdateCustomer(CustomerDTO customer)
        {
            var existingUser = Context.Customers.First(x => x.Id == customer.Id);
            if (existingUser == null) return false;
            existingUser= mapper.Map<CustomerDTO, Customer>(customer);
            return Update(existingUser);
        }

        public string GetHashStringSHA256(string str,string salt)
        {
            SHA256 sHA256 = SHA256.Create();
            byte[] hashPassword = sHA256.ComputeHash(Encoding.UTF8.GetBytes(str+salt));
            string result = "";
            foreach (byte b in hashPassword)
            {
                result += b.ToString();
            }
            return result;
        }

        public bool DeleteCustomer(int id)
        {
            var user = GetById(id);
            return Delete(user);
        }
    }
}
