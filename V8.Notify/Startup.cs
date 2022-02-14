using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V8.Notify.CustomHub;
using V8.Notify.CustomHub.WebHub;
using V8Notify.Application.AutoMapper;
using V8Notify.Application.Services;
using V8Notify.Domain.Interfaces;
using V8Notify.Infrastructure.Contexts;
using V8Notify.Infrastructure.Repositories;

namespace V8.Notify
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IV8NotifyRepositoryWrapper, V8NotifyRepositoryWrapper>();
            //Inject logic services
            services.DependencyInjectionService();
            services.AddControllers();
            services.AddDbContext<V8NotifyContext>(o => o.UseSqlServer(Configuration.GetConnectionString("V8Notify")));
            services.AddCors();
            services.AddSignalR();

            //AutoMapper
            V8AutoMapper.Configure(services);
            //services.AddScoped<IDasRepositoryWrapper, DasRepositoryWrapper>();
            //  services.AddSingleton<IConnectionManager, ConnectionManager>();
            services.AddSingleton<ConnectionManager>();
            services.AddTransient<Func<string, IConnectionManager>>(serviceProvider => key =>
            {
                return key switch
                {
                    "V8Web" => serviceProvider.GetService<ConnectionManager>(),
                    _ => throw new Exception($"No service registered for IConnectionManager"),
                };
            });
            services.AddSingleton<HubNotifyHelper>();
            services.AddTransient<Func<string, IHubNotifyHelper>>(serviceProvider => key =>
            {
                return key switch
                {
                    "V8Web" => serviceProvider.GetService<HubNotifyHelper>(),
                    _ => throw new Exception($"No service registered for IHubNotifyHelper"),
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotifyHub>("/NotificationHub");
            });
        }
    }
}
