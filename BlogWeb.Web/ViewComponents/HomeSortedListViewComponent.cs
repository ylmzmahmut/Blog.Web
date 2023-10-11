using AutoMapper;
using BlogWeb.Data.UnitOfWorks;
using BlogWeb.Entity.Entities;
using BlogWeb.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Web.ViewComponents
{
    public class HomeSortedListViewComponent: ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public HomeSortedListViewComponent(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<Article>>(articles);
           

            return View(map.OrderByDescending(x => x.ViewCount)
            .Take(3)
            .ToList());
        }
    }
}
