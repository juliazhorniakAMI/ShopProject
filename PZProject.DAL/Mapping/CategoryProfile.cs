using AutoMapper;
using CursovaApp.Models;
using PZProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PZProject.DAL.Mapping
{
   public class CategoryProfile:Profile
    {

        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
