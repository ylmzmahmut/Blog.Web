using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Entity.DTOs.Images;
using BlogWeb.Entity.Enums;
using Microsoft.AspNetCore.Http;

namespace BlogWeb.Service.Helpers
{
    public interface IIamgeHelper
    {
        Task<ImageUploadedDTO> Upload(string name, IFormFile imageFile, ImageType imageType , string folderName = null);
        void Delete(string imageName);
    }
}
