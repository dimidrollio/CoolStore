﻿using CoolStore.DataAccess.Data;
using CoolStore.DataAccess.Repository.IRepository;
using CoolStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolStore.DataAccess.Repository 
{ 
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private ApplicationDBContext _db;
		public CategoryRepository(ApplicationDBContext db) : base(db)
		{
			_db = db;
		}
	}
}
