using AutoMapper;
using CursovaApp.Models;
using PZProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PZProject.DAL.Mapping
{
   public class OrderDetailProfile:Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        }
    }
}
