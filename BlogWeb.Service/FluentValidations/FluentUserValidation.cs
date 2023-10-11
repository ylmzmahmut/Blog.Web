using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Entity.Entities;
using FluentValidation;

namespace BlogWeb.Service.FluentValidations
{
    public class FluentUserValidation : AbstractValidator<AppUser>
    {
        public FluentUserValidation()
        {
            RuleFor(x => x.FirstName)
             .NotEmpty()
             .MinimumLength(3)
             .MaximumLength(50)
             .WithName("İsim");

            RuleFor(x => x.LastName)
             .NotEmpty()
             .MinimumLength(3)
             .MaximumLength(50)
             .WithName("Soyisim");

            RuleFor(x => x.PhoneNumber)
             .NotEmpty()
             .MinimumLength(11)
             .WithName("Telefon numarası");
        }
    }
}
