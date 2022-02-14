using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V8Hangfire.Application.AutoMapper;
using V8Hangfire.Application.Interfaces;
using V8Hangfire.Application.Services;
using V8Hangfire.Domain.Interfaces.V8Hangfire;
using V8Hangfire.Infrastructure.Contexts;
using V8Hangfire.Infrastructure.HttpClientAccessors.Implementations;
using V8Hangfire.Infrastructure.HttpClientAccessors.Interfaces;
using V8Hangfire.Infrastructure.Repositories.V8Hangfire;

namespace V8.HangFire
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
            services.AddDbContext<V8HangfireContext>(o => o.UseSqlServer(Configuration.GetConnectionString("V8Hangfire")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IV8ClientServices, V8ClientService>(); //service use BaseHttpClientFactory must be Singleton

            services.AddControllers();

            services.AddHttpClient<IBaseHttpClient, BaseHttpClient>();   //Transient, don't Inject to Scope or Singleton
            services.AddSingleton<IBaseHttpClientFactory, BaseHttpClientFactory>();

            #region configure hangfire
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("V8Hangfire")));
            services.AddHangfireServer();
            #endregion

            //V8AutoMapper.Configure(services);

            services.AddScoped<IV8HangfireRepositoryWrapper, V8HangfireRepositoryWrapper>();
            //services.DependencyInjectionService();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseHangfireDashboard();
        }
    }
}
