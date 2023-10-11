using BlogWeb.Entity.Entities;
using BlogWeb.Service.Services.Abstractions;
using BlogWeb.Service.Services.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticelService articleService;
        

        public HomeController(IArticelService articleService)
        {
            this.articleService = articleService;
         
        }
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllArticleAsync();
            

            return View(articles);
        }
    }
}
