using App.Data.Core;
using App.Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace App.Data.Infrastructure
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context)
            : base(context)
        {

        }
    }
}
