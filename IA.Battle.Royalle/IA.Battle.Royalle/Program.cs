/// <summary>
/// IA.Battle.Royalle.Console
/// </summary>

namespace IA.Battle.Royalle.Console
{

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using System;

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
        /// <param name="args">string[] args</param>
        /// <returns>static IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var webHost = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseUrls($"http://0.0.0.0:{config.GetValue<int>("Host:Port")}")
                    .UseStartup<Startup>();
                }).UseWindowsService();

            return webHost;
        }
    }
}
