/// <summary>
/// IA.Battle.Royalle.Console
/// </summary>

namespace IA.Battle.Royalle.Console
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using IA.Battle.Royalle.Application.Services;
    using IA.Battle.Royalle.Domain.Interfaces.Services;

    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// IServiceInformation
        /// </summary>
        private readonly IServiceInformation _serviceInformation;

        /// <summary>
        /// IConfiguration
        /// </summary>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="_configuration">IConfiguration _configuration</param>
        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
            _serviceInformation = new ServiceInformation(_configuration);
        }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services">IServiceCollection services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IServiceInformation, ServiceInformation>();
            services.AddScoped<IComandoService, ComandoService>();
            services.AddControllers();

            services.AddOptions();
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app">IApplicationBuilder app</param>
        /// <param name="env">IWebHostEnvironment env</param>
        /// <param name="applicationLifetime">IHostApplicationLifetime applicationLifetim</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStarted.Register(OnStart);
            applicationLifetime.ApplicationStopping.Register(OnShutdown);
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// OnStart
        /// </summary>
        private void OnStart()
        {
            _serviceInformation.Subscribe();
        }

        /// <summary>
        /// OnShutdown
        /// </summary>
        private void OnShutdown()
        {
            _serviceInformation.Unsubscribe();
        }
    }
}