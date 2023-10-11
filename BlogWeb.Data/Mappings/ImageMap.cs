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
	public class ImageMap : IEntityTypeConfiguration<Image>

	{
		public void Configure(EntityTypeBuilder<Image> builder)
		{
			builder.HasData(new Image
			{
				Id = Guid.Parse("944BD0C6-864B-4148-B771-270B7391AEA0"),
				FileName ="images/testimage",
				FileType = "jpg",
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			},
			new Image
			{
				Id = Guid.Parse("553DF9B1-7C6F-42D5-8335-70BDDA4DFF40"),
				FileName = "images/vstest",
				FileType = "png",
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			});
		}
	}
}
