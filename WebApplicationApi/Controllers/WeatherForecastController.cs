using AutoMapper;
using BlogWeb.Data.Context;
using BlogWeb.Data.UnitOfWorks;
using BlogWeb.Entity.DTOs.Articles;
using BlogWeb.Entity.Entities;
using BlogWeb.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {



        private readonly AppDbContext appDbContext;
        private readonly IArticelService articelService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WeatherForecastController(AppDbContext appDbContext, IArticelService articelService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.articelService = articelService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pc = appDbContext.articles.ToList();
            return Ok(pc);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            
            var article = appDbContext.articles.FirstOrDefault(x => x.Id == id);
            return Ok(article);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ArticleAddDTO articleAddDTO)
        {
            var article = articelService.CreateArticleAsync(articleAddDTO);
            var map = mapper.Map<Article>(article);
            return Ok(map);
        }

        [HttpPut("{id}")]
        public  IActionResult UpdateProduct(Guid id, ArticleDTO entity)
        {
            if (id.Equals(entity.Id) == false)
            {
                return BadRequest();
            }

            var product = appDbContext.articles.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Title = entity.Title;
            product.Content = entity.Content;
            unitOfWork.Save();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var product = appDbContext.articles.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            articelService.SafeDeleteArticleAsync(id);
            return NoContent();
        }

    }
}