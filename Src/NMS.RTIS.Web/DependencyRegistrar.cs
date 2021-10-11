/**********************************************************************
* 命名空间：NMS.RTIS.Web.Infrastructure
*
* 功  能：autofac依赖注入配置
* 类  名：DependencyRegistrar
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Autofac;
using NMS.RTIS.Infrastructure.EntityFrameworkCore;
using NMS.RTIS.Infrastructure.Repositories;
using NMS.RTIS.Service.File;
using Module = Autofac.Module;

namespace NMS.RTIS.Web.Infrastructure
{
    public class DependencyRegistrar : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //仓储
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            //上下文
            builder.RegisterType<ApplicationDbContext>().AsSelf();

            #region 基础服务
            builder.RegisterType<FileService>().As<IFileService>().InstancePerLifetimeScope();
            #endregion
        }
    }
}
