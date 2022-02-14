using Microsoft.Extensions.DependencyInjection;
using System;
using V8Hangfire.Infrastructure.HttpClientAccessors.Interfaces;

namespace V8Hangfire.Infrastructure.HttpClientAccessors.Implementations
{
    public class BaseHttpClientFactory : IBaseHttpClientFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public BaseHttpClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IBaseHttpClient Create()
        {
            return _serviceProvider.GetRequiredService<IBaseHttpClient>();
        }
    }
}
