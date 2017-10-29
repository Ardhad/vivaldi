using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Vivaldi.Api.DataAccess;
using Vivaldi.Api.Domain;
using Vivaldi.DataAccess;
using Vivaldi.Domain;

namespace Vivaldi.Web
{
    public class IocConfig
    {
        public static void RegisterContainer(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            RegisterMvcAndWebApiResolvers(builder);
            RegisterDataAccess(builder);
            RegisterDomainServices(builder);

            ConfigureDependencyResolvers(builder, configuration);
        }

        private static void RegisterMvcAndWebApiResolvers(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
        }

        private static void RegisterDomainServices(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(DomainIocFaker).Assembly)
                .Where(type => type.GetInterfaces().Contains(typeof(IDomainService)))
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }

        private static void RegisterDataAccess(ContainerBuilder builder)
        {
            builder.RegisterType<VivaldiDbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UnitOfWork).Assembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }

        private static void ConfigureDependencyResolvers(ContainerBuilder builder, HttpConfiguration httpConf)
        {
            var container = builder.Build();

            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            httpConf.DependencyResolver = webApiResolver;

            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }
}