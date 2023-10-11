using BlogWeb.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Web.ViewComponents
{
    public class HomeCategoriesViewComponent: ViewComponent
    {
        private readonly ICategoryService categoryService;

        public HomeCategoriesViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await categoryService.GetAllCategories15();
            return View(categories);
        }
    }
}
