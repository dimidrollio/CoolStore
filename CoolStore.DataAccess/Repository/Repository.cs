﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoolStore.DataAccess.Data;
using CoolStore.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CoolStore.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDBContext _db;
		internal DbSet<T> dbSet;
		public Repository(ApplicationDBContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}
		public void Update(T entity)
		{
			dbSet.Update(entity);
		}

		public T Get(Expression<Func<T, bool>> filter, string? incluceProperties = null)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filter);
			if (!string.IsNullOrEmpty(incluceProperties))
			{
				foreach (var includeProp in incluceProperties
					.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll(string? incluceProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (!string.IsNullOrEmpty(incluceProperties))
			{
				foreach (var includeProp in incluceProperties
					.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}
			return query.ToList();
		}
		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}
		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}
	}
}