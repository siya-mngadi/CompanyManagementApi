﻿using CompanyManagement.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CompanyManagement.Repositories.Metered
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected RepositoryContext Context;

		public RepositoryBase(RepositoryContext context)
		{
			Context = context;
		}

		public void Update(T entity) => Context.Set<T>().Update(entity);

		public void Create(T entity) => Context.Set<T>().Add(entity);

		public void Delete(T entity) => Context.Set<T>().Remove(entity);

		public IQueryable<T> FindAll(bool trackChanges)
		{
			return !trackChanges ? 
				Context.Set<T>().AsNoTracking() :
				Context.Set<T>();
		}

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
		{
			return !trackChanges ? Context.Set<T>()
				.Where(expression)
				.AsNoTracking() :
				Context.Set<T>()
				.Where(expression);
		}
	}
}
