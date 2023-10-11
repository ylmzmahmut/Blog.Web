using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Entity.DTOs.Categories;
using BlogWeb.Entity.Entities;
using FluentValidation;

namespace BlogWeb.Service.FluentValidations
{
    public class FluentCategoryValidator : AbstractValidator<Category>
    {
        public FluentCategoryValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty()
               .NotNull()
               .MinimumLength(3)
               .MaximumLength(100)
               .WithName("Kategori Adı");
        }
    }
}
