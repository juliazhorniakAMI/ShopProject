using AutoMapper;
using CursovaApp.Models;
using PZProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PZProject.DAL.Mapping
{
   public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
