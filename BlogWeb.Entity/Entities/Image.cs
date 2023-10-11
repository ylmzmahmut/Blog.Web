using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Core.Entities;
using BlogWeb.Entity.Enums;

namespace BlogWeb.Entity.Entities
{
	public class Image : EntityBase
	{
		
		public string FileName { get; set; }

        public string FileType { get; set; }

        public string CreatedBy { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<AppUser> Users { get; set; }
    }
}
