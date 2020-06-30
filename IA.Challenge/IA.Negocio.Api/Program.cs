
/// <summary>
/// IA - Instituto Atlântico
/// </summary>

namespace IA
{

    using System;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">string[] args</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="args">string[] arg</param>
        /// <returns>IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseUrls($"http://0.0.0.0:{config.GetValue<int>("Host:Port")}")
                    .UseStartup<Startup>();
                }).UseWindowsService();

            return host;
        }
    }
}
