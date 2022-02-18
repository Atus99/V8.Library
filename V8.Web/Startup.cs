using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using V8.Application.AutoMapper;
using V8.Application.Services;
using V8.Domain.Interfaces.V8;
using V8.Domain.Interfaces.V8Notify;
using V8.Infrastructure.Contexts;
using V8.Infrastructure.Repositories.Dapper;
using V8.Infrastructure.Repositories.V8;
using V8.Infrastructure.Repositories.V8Notify;
using V8.Utility.LogUtils;

namespace V8.Web
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var appBasePath = string.IsNullOrEmpty(Configuration["LogsFolder"]) ? Directory.GetCurrentDirectory() : Configuration["LogsFolder"];
            NLog.GlobalDiagnosticsContext.Set("appbasepath", appBasePath);
            NLog.LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config")).GetCurrentClassLogger();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<V8Context>(o => o.UseSqlServer(Configuration.GetConnectionString("V8Context")));
            services.AddDbContext<V8NotifyContext>(o => o.UseSqlServer(Configuration.GetConnectionString("V8Nofity")));

            //Add dapper connection
            ConfigDapperContext(services);

            services.AddControllers();

            services.AddSingleton<IloggerManager, LoggerManager>();

            services.AddMvcCore().AddNewtonsoftJson();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IV8NotifyRepositoryWrapper, V8NotifyRepositoryWrapper>();
            services.AddScoped<IV8RepositoryWrapper, V8RepositoryWrapper>();

            //Inject logic services
            services.DependencyInjectionService();

            //Auto mapper
            V8AutoMapper.Configure(services);
        }

        public void ConfigDapperContext(IServiceCollection services)
        {
            var connectionDict = new Dictionary<DatabaseConnectionName, string>
            {
                { DatabaseConnectionName.V8Connection, this.Configuration.GetConnectionString("V8Context") }
            };

            services.AddSingleton<IDictionary<DatabaseConnectionName, string>>(connectionDict);

            services.AddScoped<IDbConnectionFactory, DapperDbConnectionFactory>();
            services.AddScoped<IV8DapperRepo, V8DapperRepo>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
