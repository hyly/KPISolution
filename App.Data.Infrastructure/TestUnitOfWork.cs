﻿using System;
using System.Collections.Generic;
using App.Data.DomainModel;
using System.Data.Entity;

namespace App.Data.Infrastructure
{
    public class TestUnitOfWork : IUnitOfWork
    {
        private IProductRepository productRepository = null;
        private DbContext context = null;
        public TestUnitOfWork(IProductRepository productRepository,DbContext context)
        {
            this.productRepository = productRepository;
            this.context = context;
        }
        public IProductRepository ProductRepository { get { return this.productRepository; } }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
