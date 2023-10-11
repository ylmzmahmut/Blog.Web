using System.Security.Claims;
using AutoMapper;
using BlogWeb.Data.UnitOfWorks;
using BlogWeb.Entity.DTOs.Articles;
using BlogWeb.Entity.Entities;
using BlogWeb.Entity.Enums;
using BlogWeb.Service.Extensions;
using BlogWeb.Service.Helpers;
using BlogWeb.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;


namespace BlogWeb.Service.Services.Concretes
{
    public class ArticleService : IArticelService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IIamgeHelper iamgeHelper;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IIamgeHelper iamgeHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.iamgeHelper = iamgeHelper;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<ArticleListDTO> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = categoryId == null
                ? await unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Image, u => u.User)
                : await unitOfWork.GetRepository<Article>().GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted,
                    a => a.Category, i => i.Image, u => u.User);
            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new ArticleListDTO
            {
                Articles = sortedArticles,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }

        public async Task CreateArticleAsync(ArticleAddDTO articleAddDTO)
        {
            var UserId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var ImageUpload = await iamgeHelper.Upload(articleAddDTO.Title, articleAddDTO.Photo, ImageType.Post);

            Image ımage = new Image
            {
                FileName = ImageUpload.FullName,
                FileType = articleAddDTO.Photo.ContentType,
                CreatedBy = userEmail
            };
            await unitOfWork.GetRepository<Image>().AddAsync(ımage);

            var article = new Article
            {
                Title = articleAddDTO.Title,
                Content = articleAddDTO.Content,
                CategoryId = articleAddDTO.CategoryId,
                UserId = UserId,
                CreatedBy = userEmail,
                ImageId = ımage.Id

            };

            await unitOfWork.GetRepository<Article>().AddAsync(article);
            await unitOfWork.SaveAsync();
            
        }

        public async Task<List<ArticleDTO>> GetAllArticleAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted, x=>x.Category);
            var map = mapper.Map<List<ArticleDTO>>(articles);

            return map;
        }

        public async Task<ArticleDTO> GetArticleAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, i => i.Image, u => u.User);
            var map = mapper.Map<ArticleDTO>(article);

            return map;
        }

        public async Task UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDTO.Id, x => x.Category, i => i.Image);

            if (articleUpdateDTO.Photo != null)
            {
                iamgeHelper.Delete(article.Image.FileName);

                var imageUpload = await iamgeHelper.Upload(articleUpdateDTO.Title, articleUpdateDTO.Photo, ImageType.Post);
                Image image = new Image
                {
                    FileName = imageUpload.FullName,
                    FileType = articleUpdateDTO.Photo.ContentType,
                    CreatedBy = userEmail
                };
                await unitOfWork.GetRepository<Image>().AddAsync(image);

                article.ImageId = image.Id;

            }

            article.Title = articleUpdateDTO.Title; 
            article.CategoryId = articleUpdateDTO.CategoryId;
            article.Content = articleUpdateDTO.Content;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();
        }

        public async Task SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await unitOfWork.GetRepository<Article>().GetbyGuidAsync(articleId);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

        }


        public async Task<string> UndoDeleteArticleAsync(Guid articleId)
        {
            var article = await unitOfWork.GetRepository<Article>().GetbyGuidAsync(articleId);

            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }


        public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryDeletedAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDTO>>(articles);

            return map;
        }


        public async Task<ArticleListDTO> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(
                a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword)),
            a => a.Category, i => i.Image, u => u.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new ArticleListDTO
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }

    }
}
