using App.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Infrastructure
{
    public class TestProductRepository : GenericRepository<App.Data.DomainModel.Entities.Product>, IProductRepository
    {
        public TestProductRepository(DbContext context)
            : base(context)
        {

        }
    }
}
