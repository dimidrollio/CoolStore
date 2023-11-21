﻿using CoolStore.DataAccess.Data;
using CoolStore.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolStore.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDBContext _db;
		public ICategoryRepository Category { get; private set; }
		public IProductRepository Product { get; private set; }
		
		public ICompanyRepository Company { get; private set; }
		
		public IShoppingCartRepository ShoppingCart { get; private set; }

		public UnitOfWork(ApplicationDBContext db)
		{
			_db = db;
			Category = new CategoryRepository(_db);
			Product = new ProductRepository(_db);
			Company = new CompanyRepository(_db);
			ShoppingCart = new ShoppingCartRepository(_db);
		}


		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
