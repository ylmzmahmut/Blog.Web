using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Entity.DTOs.Images;
using BlogWeb.Entity.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BlogWeb.Service.Helpers
{
    public class ImageHelper : IIamgeHelper
    {

        private readonly string wwwroot;
        private readonly IWebHostEnvironment env;
        private const string imgFolder = "images";
        private const string articleImagesFolder = "article-images";
        private const string userImagesFolder = "user-images";


        public ImageHelper(IWebHostEnvironment env)
        {
            this.env = env;
            wwwroot = env.WebRootPath;
        }


        


        public async Task<ImageUploadedDTO> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null)
        {
            folderName ??= imageType == ImageType.User ? userImagesFolder : articleImagesFolder;

            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");


            var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", imageFile.FileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();

     
            return new ImageUploadedDTO()
            {
                FullName = $"{folderName}/{imageFile.FileName}"
            };
        }

        public void Delete(string imageName)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/{imageName}");
            if (File.Exists(fileToDelete))
                File.Delete(fileToDelete);
        }
    }
}
