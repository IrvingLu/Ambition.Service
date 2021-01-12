using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace Identity.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(
                    options =>
                    {
                        options.Limits.MinRequestBodyDataRate = null;//½â¾ö
                        options.AddServerHeader = false;
                        options.Listen(IPAddress.Any, 5000);
                    });
                });
    }
}
