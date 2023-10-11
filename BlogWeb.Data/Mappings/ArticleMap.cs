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
	internal class ArticleMap : IEntityTypeConfiguration<Article>
	{
		private const int V = 15;

		public void Configure(EntityTypeBuilder<Article> builder)
		{
			builder.HasData(new Article
			{
				Id=Guid.NewGuid(),
				Title="Deneme makalesi 1",
				Content = "asuhfşısafashfpashfasıufhasıpfgasfasfasfasf",
				ViewCount = 15,
				CategoryId = Guid.Parse("F4EFFD4C-7459-4E96-A759-090ACC20A572"),
				ImageId = Guid.Parse("944BD0C6-864B-4148-B771-270B7391AEA0"),
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false,
				UserId = Guid.Parse("6DE21C5E-6C86-4912-AB4D-5411B56657F2")
            },
			new Article
			{
				Id = Guid.NewGuid(),
				Title = "Visual Studio makalesi 1",
				Content = "uuuuuuuuuuuuoooooooooooo",
				ViewCount = 15,
				CategoryId = Guid.Parse("983D6AFC-B1DF-4677-BACE-BB9DDB4415DE"),
				ImageId = Guid.Parse("553DF9B1-7C6F-42D5-8335-70BDDA4DFF40"),
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false,
                UserId = Guid.Parse("2251144B-5B3F-45E9-8297-10850635BA43")
            });
		}
	}
}
