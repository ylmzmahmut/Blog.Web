using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid ImageId { get; set; } = Guid.Parse("944BD0C6-864B-4148-B771-270B7391AEA0");
        public Image Image { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
