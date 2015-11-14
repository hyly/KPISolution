using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace App.Data.Infrastructure
{
    public class AppDataInitializer : DropCreateDatabaseIfModelChanges<TestDataContext>
    {
        protected override void Seed(TestDataContext context)
        {
            context.Products.Add(new DomainModel.Entities.Product() { 
                Active=true,Color="Yellow",Name="Test Product 1",Price=189
            });
            context.Products.Add(new DomainModel.Entities.Product()
            {
                Active = true,
                Color = "Yellow",
                Name = "Test Product 2",
                Price = 189
            });
            context.Products.Add(new DomainModel.Entities.Product()
            {
                Active = true,
                Color = "Yellow",
                Name = "Test Product 3",
                Price = 189
            });
            context.Products.Add(new DomainModel.Entities.Product()
            {
                Active = true,
                Color = "Yellow",
                Name = "Test Product 4",
                Price = 189
            });
            context.Products.Add(new DomainModel.Entities.Product()
            {
                Active = true,
                Color = "Yellow",
                Name = "Test Product 5",
                Price = 189
            });
            context.Products.Add(new DomainModel.Entities.Product()
            {
                Active = true,
                Color = "Yellow",
                Name = "Test Product 6",
                Price = 189
            });
            base.Seed(context);
        }
    }
}
