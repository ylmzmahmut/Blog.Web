using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Data.Abstractions;
using BlogWeb.Data.Concretes;
using BlogWeb.Data.Context;
using BlogWeb.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogWeb.Data.Extensions
{
	public static class DataLayerExtensions
	{
		public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
		{
			services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
			services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
			
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			return services;

		}
	}
}
