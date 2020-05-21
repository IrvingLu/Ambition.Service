using Autofac;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Sfan.Core.Domain.Identity;
using Sfan.Infrastructure;
using Sfan.Infrastructure.EntityFrameworkCore;
using Sfan.Web.Infrastructure;
using Sfan.Web.Infrastructure.StartupExtensions;

namespace Sfan.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //����http������
            services.AddHttpContextAccessor();
            IdentityModelEventSource.ShowPII = true;//��ʾ�������ϸ��Ϣ���鿴����
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddApplicationDbContext(Configuration);//DbContext������
            services.AddIdentityOptions();
            services.AddAutoMapper(typeof(Startup));//autoap
            services.AddMediatR(typeof(Startup));//CQRS
            services.AddHealthChecks();//�������
            services.AddAuthService(Configuration);//��֤����
            services.AddApiVersion();//api�汾
            services.AddController();//api������
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                  .AddEntityFrameworkStores<ApplicationDbContext>()
                  .AddDefaultTokenProviders();//Identity ע��

        }
        /// <summary>
        /// �м���ܵ�
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHealthChecks("/health");
            app.UseApiVersioning();
            app.UseLog4net();
            app.UseErrorHandling();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //��ʼ������
            DbContextSeed.SeedAsync(app.ApplicationServices).Wait();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyRegistrar());
        }
    }

}
