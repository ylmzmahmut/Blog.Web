using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogWeb.Entity.DTOs.Categories;
using BlogWeb.Entity.Entities;

namespace BlogWeb.Service.AutoMapper.Categories
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO,Category>().ReverseMap();
            CreateMap<CategoryAddDTO, Category>().ReverseMap();
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
        }
    }
}
