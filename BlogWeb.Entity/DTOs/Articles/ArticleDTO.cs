using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Entity.DTOs.Categories;
using BlogWeb.Entity.Entities;

namespace BlogWeb.Entity.DTOs.Articles
{
    public class ArticleDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryDTO Category { get; set; }
        public string CreatedBy { get; set; }
        public Image Image { get; set; }

        public AppUser User { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public int ViewCount { get; set; }
    }
}
