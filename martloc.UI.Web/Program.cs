using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using martloc.infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace financeiro.UI.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //var host = BuildWebHost(args);
            using (var scope= host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<BackendContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Um erro ocorreu no metodo seeding do contexto!");
                    throw;
                }

            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {



                    webBuilder.UseUrls("http://0.0.0.0:5000");

                    webBuilder.UseStartup<Startup>();
                });
    }
}
