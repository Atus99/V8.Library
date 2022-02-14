using System;
using System.Collections.Generic;
using System.Text;

namespace V8Hangfire.Infrastructure.HttpClientAccessors.Interfaces
{
    public interface IBaseHttpClientFactory
    {
        IBaseHttpClient Create();
    }
}
