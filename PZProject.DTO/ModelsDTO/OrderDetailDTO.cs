using System;
using System.Collections.Generic;

#nullable disable

namespace CursovaApp.Models
{
    public partial class OrderDetailDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double TotalSum { get; set; }
        public virtual OrderDTO Order { get; set; }
        public virtual ProductDTO Product { get; set; }
    }
}
