using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using App.Services.Implementation;
using App.Services.Core;
using App.Data.Infrastructure;
using App.Data.Core;
using Autofac.Configuration;
using System.Data.Entity;
namespace App.Data.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var builder = new ContainerBuilder();

            // You can register controllers all at once using assembly scanning...
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ProductServices>().As<IProductServices>().InstancePerRequest();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<TestUnitOfWork>().As<App.Data.DomainModel.IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<TestProductRepository>().As<App.Data.DomainModel.IProductRepository>().InstancePerRequest();
            //builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerRequest();
            //builder.RegisterType<UserProfileRepository>().As<IUserProfileRepository>().InstancePerRequest();
            //builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<TestDataContext>().As<DbContext>()
                .WithParameter(new NamedParameter("nameConnectionString", "TestData"))
                .InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
