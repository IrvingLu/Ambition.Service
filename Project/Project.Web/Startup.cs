using Autofac;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Project.Core.Domain.Identity;
using Project.Infrastructure;
using Project.Infrastructure.Core;
using Project.Infrastructure.EntityFrameworkCore;
using Project.Web.Appliccation.SignalrRHub;
using Project.Web.Infrastructure;
using Project.Web.StartupExtensions;
using System.Text;

namespace Project.Web
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
            RedisHelper.Initialization(new CSRedis.CSRedisClient(Configuration.GetConnectionString("CsRedisCachingConnectionString")));  //redis����
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//���.netcore ��������
            IdentityModelEventSource.ShowPII = true;//��ʾ�������ϸ��Ϣ���鿴����
            services.AddHttpContextAccessor();//����http������
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;//�����ȡ�ļ���
            });
            services.AddScoped<IUnitOfWork>(m => m.GetService<ApplicationDbContext>());
            services.AddCorsConfig();//��������
            services.AddConfig(Configuration);//�����ļ�
            services.AddIdentityOptions();//�����֤����
            services.AddAutoMapper(typeof(Startup));//automapper
            services.AddMediatR(typeof(Startup));//CQRS
            services.AddHealthChecks();//�������
            services.AddSignalR();//SignalR
            services.AddApiVersion();//api�汾
            services.AddController();//api������
            //services.AddLogging();
            services.AddIdentity<ApplicationUser,ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();//Identity ע��
            services.AddAuthService(Configuration);//��֤����
        }
        /// <summary>
        /// �м���ܵ�
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors("AllowSameDomain");//����
            app.UseAuthentication();//��֤
            app.UseAuthorization();//��Ȩ
            app.UseHealthChecks("/health");//�������
            app.UseApiVersioning();//�汾
            app.UseErrorHandling();//�쳣����
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ProjectHub>("/project").RequireCors(t => t.WithOrigins(new string[] { "null" }).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
            DbContextSeed.SeedAsync(app.ApplicationServices).Wait();//������ʼ������
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
