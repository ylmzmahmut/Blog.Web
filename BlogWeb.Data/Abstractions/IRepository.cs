﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Core.Entities;
using BlogWeb.Entity.Entities;

namespace BlogWeb.Data.Abstractions
{
	public interface IRepository<T> where T : class,IEntityBase,new()
	{
		Task AddAsync(T entity);
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
		Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
		Task<T> GetbyGuidAsync(Guid id);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);

		Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
		Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        
    }

}
