using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Infrastructure
{
    public class TestDataContext : DbContext
    {
        public TestDataContext(string nameConnectionString)
            : base(nameConnectionString)
        {
            Database.SetInitializer<TestDataContext>(new AppDataInitializer());
        }
        public virtual IDbSet<App.Data.DomainModel.Entities.Product> Products { get; set; }
    }
}
