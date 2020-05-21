using Autofac;
using Microsoft.AspNetCore.Identity;
using Sfan.Core.Domain.Identity;
using Sfan.Infrastructure.Dapper;
using Sfan.Infrastructure.EntityFrameworkCore;
using Sfan.Infrastructure.Repositories;
using Sfan.Web.Application.CommandHandler;
using Sfan.Web.Application.Project.Commands;
using System.Reflection;
using Module = Autofac.Module;

namespace Sfan.Web.Infrastructure
{
    public class DependencyRegistrar : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //data
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(DapperQuery<>)).As(typeof(IDapperQuery<>)).InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().AsSelf();
            //注入command
            builder.RegisterAssemblyTypes(typeof(CustomerCommandHandler).GetTypeInfo().Assembly);
            builder.RegisterAssemblyTypes(typeof(CreateCashArrearsCommandHandler).GetTypeInfo().Assembly);
        }
    }
}
