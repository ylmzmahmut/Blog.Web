using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Entity.DTOs.Categories;
using BlogWeb.Entity.Entities;

namespace BlogWeb.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategories();

        Task<List<CategoryDTO>> GetAllCategoriesDeleted();
        Task CreateCategoryAsync(CategoryAddDTO categoryAddDto);

        Task<Category> GetCategoryByGuid(Guid id);

        Task<string> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdateDto);

        Task<string> SafeDeleteCategoryAsync(Guid categoryId);
        Task<string> UndoDeleteCategoryAsync(Guid categoryId);
        Task<List<CategoryDTO>> GetAllCategories15();
    }
}
