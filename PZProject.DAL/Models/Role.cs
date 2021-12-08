using System;
using System.Collections.Generic;

#nullable disable

namespace PZProject.DAL.Models
{
    public partial class Role
    {
        public Role()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
