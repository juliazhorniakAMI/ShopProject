using System;
using System.Collections.Generic;

#nullable disable

namespace PZProject.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Pass { get; set; }
        public virtual Role Role { get; set; }
        public Guid Salt { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
