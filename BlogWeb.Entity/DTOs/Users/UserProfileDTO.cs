using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Entity.Entities;
using Microsoft.AspNetCore.Http;

namespace BlogWeb.Entity.DTOs.Users
{
    public class UserProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public IFormFile? Photo { get; set; }
        public Image? Image { get; set; }
    }
}
