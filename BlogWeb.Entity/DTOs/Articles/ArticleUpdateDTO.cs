using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Entity.DTOs.Categories;
using BlogWeb.Entity.Entities;
using Microsoft.AspNetCore.Http;

namespace BlogWeb.Entity.DTOs.Articles
{
    public class ArticleUpdateDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }

        public Image Image { get; set; }

        public IFormFile Photo { get; set; }

        public IList<CategoryDTO> Categories { get; set; }
    }
}
