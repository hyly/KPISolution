using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.WebApi;
using App.Services.Implementation;
using App.Services.Core;
using App.Data.Infrastructure;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Http;
namespace App.Web.Api
{
    public class Bootstrapper
    {
        public static void Run(HttpConfiguration config)
        {
            ObjectMapper.CreateObjectServicesMap();
            var builder = new ContainerBuilder();

            // You can register controllers all at once using assembly scanning...
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterType<ProductServices>().As<IProductServices>().InstancePerRequest();
            builder.RegisterType<KPIUnitOfWork>().As<App.Data.DomainModel.IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<App.Data.DomainModel.IProductRepository>().InstancePerRequest();
            builder.RegisterType<KPIDataContext>().As<DbContext>()
                .WithParameter(new NamedParameter("nameConnectionString", "TestData"))
                .InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}