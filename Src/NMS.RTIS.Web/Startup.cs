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
            services.AddController();//api������
            services.AddIdentity<ApplicationUser,ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();//Identity ע��
            services.AddAuthService(Configuration);//��֤����
            services.AddSwaggerGen(c =>
            {
                typeof(ApiVersionEnum).GetEnumNames().ToList().ForEach(version =>
                {
                    c.SwaggerDoc(version, new OpenApiInfo()
                    {
                        Title = $"{typeof(Startup).Namespace}",
                        Version = version,
                        Description = $"{version} �汾���ɸ�����Ҫѡ��",
                        Contact = new OpenApiContact
                        {
                            Name = "����ҽ��ϵͳ�ɷ����޹�˾",
                            Email = "nms-admin@neusoftmedical.com",
                            Url = new Uri("http://www.neusoftmedical.com/")
                        },
                    });
                });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Namespace}" + ".xml");
                c.IncludeXmlComments(xmlPath, true);
            });
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
            app.UseErrorHandling();//�쳣����
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                typeof(ApiVersionEnum).GetEnumNames().ToList().ForEach(version =>
                {
#if DEBUG
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{version}");
#else
                    c.SwaggerEndpoint($"./swagger/{version}/swagger.json", $"{version}");
#endif
                });
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseIdentityServer();
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
