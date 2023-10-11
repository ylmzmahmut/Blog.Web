using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogWeb.Entity.DTOs.Users;
using BlogWeb.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Service.AutoMapper.Users
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, AppUser>().ReverseMap();
            CreateMap<UserAddDTO, AppUser>().ReverseMap();
            CreateMap<UserUpdateDTO, AppUser>().ReverseMap();
            CreateMap<UserProfileDTO, AppUser>().ReverseMap();
        }
    }
}
