using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Entity.DTOs.Articles;
using BlogWeb.Entity.Entities;

namespace BlogWeb.Service.Services.Abstractions
{
    public interface IArticelService
    {
        Task<List<ArticleDTO>> GetAllArticleAsync();
        Task<ArticleDTO> GetArticleAsync(Guid articleId);
        Task CreateArticleAsync(ArticleAddDTO articleAddDTO);

        Task UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO);

        Task SafeDeleteArticleAsync(Guid articleId);
        Task<string> UndoDeleteArticleAsync(Guid articleId);
        Task<List<ArticleDTO>> GetAllArticlesWithCategoryDeletedAsync();
        Task<ArticleListDTO> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<ArticleListDTO> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);
    }
}
