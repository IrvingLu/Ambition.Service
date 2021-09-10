using Autofac;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using NMS.RTIS.Core.Tools;
using NMS.RTIS.Domain.Identity;
using NMS.RTIS.Infrastructure;
using NMS.RTIS.Infrastructure.Core;
using NMS.RTIS.Infrastructure.EntityFrameworkCore;
using NMS.RTIS.Web.Appliccation.SignalrRHub;
using NMS.RTIS.Web.Infrastructure;
using NMS.RTIS.Web.StartupExtensions;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace NMS.RTIS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        /// <summary>
        /// ����ע��
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices(Configuration);
        }
        /// <summary>
        /// �м���ܵ�
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseConfig();
           
        }
        /// <summary>
        /// autofac����ע��
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyRegistrar());
        }
    }

}
