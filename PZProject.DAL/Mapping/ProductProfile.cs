using AutoMapper;
using CursovaApp.Models;
using PZProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PZProject.DAL.Mapping
{
  public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
