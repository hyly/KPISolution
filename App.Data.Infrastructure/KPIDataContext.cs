using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Infrastructure
{
    public class KPIDataContext : DbContext
    {
        public KPIDataContext(string nameConnectionString)
            : base(nameConnectionString)
        {
            Database.SetInitializer<KPIDataContext>(new KPIDataInitializer());
        }
        public virtual IDbSet<App.Data.DomainModel.Entities.Product> Products { get; set; }
    }
}
