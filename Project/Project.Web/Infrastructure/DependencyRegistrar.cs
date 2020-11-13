using Autofac;
using Project.Infrastructure.EntityFrameworkCore;
using Project.Infrastructure.Repositories;
using Project.Web.Application.CustomerApp;
using System.Reflection;
using Module = Autofac.Module;

namespace Project.Web.Infrastructure
{
    public class DependencyRegistrar : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //data
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().AsSelf();
            //注入command
            builder.RegisterAssemblyTypes(typeof(CustomerCommandHandler).GetTypeInfo().Assembly);
        }
    }
}
