﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Core.Entities;
using BlogWeb.Data.Abstractions;

namespace BlogWeb.Data.UnitOfWorks
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IRepository<T> GetRepository<T>() where T : class, IEntityBase,new();

		Task<int> SaveAsync();

		int Save();
	
	}
}
