using System;
using System.Collections.Generic;

#nullable disable

namespace PZProject.DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string FullName { get; set; }
        public double Price { get; set; }

       public virtual Category Category { get; set; }
       public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
