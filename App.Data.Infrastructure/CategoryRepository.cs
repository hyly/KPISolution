using App.Data.Core;
using App.Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace App.Data.Infrastructure
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(DbContext context)
            :base(context)
        {

        }
    }
}
