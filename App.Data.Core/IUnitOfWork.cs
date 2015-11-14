using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository productRepository { get; }
        ICategoryRepository categoryRepository { get; }
        IUserRepository userRepository { get; }
        IUserProfileRepository userProfileRepository { get; }
        void Commit();
    }
}
