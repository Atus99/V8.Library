using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using V8Hangfire.Application.Interfaces;

namespace V8Hangfire.Application.Services
{
    public static class DIServiceWrapper
    {
        public static void DependencyInjectionService(this IServiceCollection services)
        {
            services.AddScoped<IScheduleServices, ScheduleService>();
        }
    }
}
