using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Data.Core;
using App.Data.Core.Entities;

namespace App.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDataContext context = new AppDataContext();
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IUserRepository _userRepository;
        private IUserProfileRepository _userProfileRepository;
        private bool dispose = false;

        public UnitOfWork(IProductRepository productRepository,ICategoryRepository categoryRepository
            ,IUserRepository userRepository,IUserProfileRepository _userProfileRepository)
        {
            this._categoryRepository = categoryRepository;
            this._productRepository = productRepository;
            this._userProfileRepository = userProfileRepository;
            this._userRepository = userRepository;
        }
        public void Dispose()
        {
            if (!dispose)
            {
              //  context.Dispose();
            }
            this.dispose = true;
        }
        public void Commit()
        {
            context.SaveChanges();
        }

        public IProductRepository productRepository
        {
            get { return this._productRepository; }
        }

        public ICategoryRepository categoryRepository
        {
            get { return this._categoryRepository; }
        }

        public IUserRepository userRepository
        {
            get { return this._userRepository; }
        }

        public IUserProfileRepository userProfileRepository
        {
            get { return this._userProfileRepository; }
        }
    }
}
