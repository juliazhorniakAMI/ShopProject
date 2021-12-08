using System;
using System.Collections.Generic;

#nullable disable

namespace PZProject.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
