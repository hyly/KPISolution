using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DomainModel
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        void Commit();
    }
}
