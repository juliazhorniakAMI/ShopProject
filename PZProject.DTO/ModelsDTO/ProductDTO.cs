using System;
using System.Collections.Generic;

#nullable disable

namespace CursovaApp.Models
{
    public partial class ProductDTO
    {

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string FullName { get; set; }
        public double Price { get; set; }


    }
}