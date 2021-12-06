using System;
using System.Collections.Generic;

#nullable disable

namespace CursovaApp.Models
{
    public partial class OrderDTO
    {
      
        public int Id { get; set; }
        public int? CustomerId { get; set; }
       public DateTime DateOfCreation { get; set; }
        public virtual CustomerDTO Customer { get; set; }
        public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; }

    }
}
