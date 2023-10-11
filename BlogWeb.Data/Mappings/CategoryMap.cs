using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogWeb.Data.Mappings
{
	public class CategoryMap : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(new Category
			{
				Id = Guid.Parse("F4EFFD4C-7459-4E96-A759-090ACC20A572"),
				Name = "ASP.NET balbala",
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			},
			new Category
			{
				Id = Guid.Parse("983D6AFC-B1DF-4677-BACE-BB9DDB4415DE"),
				Name = "C# balbala",
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			});
		}
	}
}
