using System;
using System.Collections.Generic;

#nullable disable

namespace CursovaApp.Models
{
    public partial class CustomerDTO
    {

        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Pass { get; set; }
        public virtual RoleDTO Role { get; set; }
        public Guid Salt { get; set; }
    }
}
