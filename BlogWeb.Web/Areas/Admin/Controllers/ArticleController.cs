using AutoMapper;
using BlogWeb.Entity.DTOs.Articles;
using BlogWeb.Entity.Entities;
using BlogWeb.Service.Extensions;
using BlogWeb.Service.Services.Abstractions;
using BlogWeb.Service.Services.Concretes;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticelService articelService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;

        public ArticleController(IArticelService articelService,ICategoryService categoryService,IMapper mapper, IValidator<Article> validator)
        {
            this.articelService = articelService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
        }

        [Authorize(Roles = "SuperAdmin, Admin, User")]
        public async Task<IActionResult> Index()
        {
            var article = await articelService.GetAllArticleAsync();
            return View(article);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> DeletedArticle()
        {
            var articles = await articelService.GetAllArticlesWithCategoryDeletedAsync();
            return View(articles);
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllCategories();
            return View(new ArticleAddDTO { Categories = categories});
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Add(ArticleAddDTO articleAddDTO)
        {
            var map = mapper.Map<Article>(articleAddDTO);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articelService.CreateArticleAsync(articleAddDTO);
                
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            var categories = await categoryService.GetAllCategories();
            return View(new ArticleAddDTO { Categories = categories });

        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await articelService.GetArticleAsync(articleId);
            var categories = await categoryService.GetAllCategories();

            var articleUpdateDTO = mapper.Map<ArticleUpdateDTO>(article);
            articleUpdateDTO.Categories = categories;

            return View(articleUpdateDTO);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Update(ArticleUpdateDTO articleUpdateDTO)
        {
            var map = mapper.Map<Article>(articleUpdateDTO);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articelService.UpdateArticleAsync(articleUpdateDTO);
                
                return RedirectToAction("Index", "Article", new { Area = "Admin" });

            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            var categories = await categoryService.GetAllCategories();
            articleUpdateDTO.Categories = categories;
            return View(articleUpdateDTO);
        }


        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            await articelService.SafeDeleteArticleAsync(articleId);
            return RedirectToAction("Index","Article",new { Area = "Admin" });
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> UndoDelete(Guid articleId)
        {
            var title = await articelService.UndoDeleteArticleAsync(articleId);

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}
