using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using V8.Application.Interfaces;

namespace V8.Application.Services
{
    public static class DIServiceWrapper
    {
        public static void DependencyInjectionService(this IServiceCollection services)
        {
            //services.AddScoped<IHttpClientService, HttpClientService>();
            //services.AddScoped<IIPAddressClientServices, IPAddressClientService>();
            //services.AddScoped<IUserService, UserService>();
        }
    }
}
