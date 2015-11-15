using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Services.Implementation;
using Autofac;
using App.Services.Core;
using Autofac.Integration.Mvc;
using App.Data.Infrastructure;
using System.Data.Entity;
using System.Web.Mvc;
namespace App.Data.Web
{
    public class Bootstrapper
    {
        public static void Run() {
            ObjectMapper.CreateObjectServicesMap();
            var builder = new ContainerBuilder();

            // You can register controllers all at once using assembly scanning...
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ProductServices>().As<IProductServices>().InstancePerRequest();
            builder.RegisterType<KPIUnitOfWork>().As<App.Data.DomainModel.IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<App.Data.DomainModel.IProductRepository>().InstancePerRequest();
            builder.RegisterType<KPIDataContext>().As<DbContext>()
                .WithParameter(new NamedParameter("nameConnectionString", "TestData"))
                .InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}