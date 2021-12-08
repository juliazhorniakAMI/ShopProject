using CursovaApp.BLL.Services.Abstract;
using PZProject.BLL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PZProject.BLL.Services
{
   public interface IServiceWrapper
    { 
       public ICategoryService catService { get; }
        public ICustomerService custService { get;  }
        public IOrderDetailsService orderDetailsService { get;  }
        public IOrderService orderService { get; }
        public IProductService prodService { get;  }
        public IRoleService roleService { get;  }
    }
}
