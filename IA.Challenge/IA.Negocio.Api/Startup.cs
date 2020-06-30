
/// <summary>
/// IA - Instituto Atlântico
/// </summary>

namespace IA
{
    using IA.Application.Services;
    using IA.Domain.Interfaces.Repositories;
    using IA.Domain.Interfaces.Services;
    using IA.Hubs;
    using IA.Infra.Data.Contexts;
    using IA.Infra.Repositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services">IServiceCollection services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:4200");
            }));

            services.AddSignalR();

            services.AddDbContext<SQLiteDbContext>();

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<SQLiteDbContext>();

            services.AddScoped<IComandoService, ComandoService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app">IApplicationBuilder app</param>
        /// <param name="env">IWebHostEnvironment env</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<SQLiteDbContext>().Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SubscriptionHub>("/services/subscription");
            });
        }
    }
}