using System;
using System.Threading.Tasks;
using V8Hangfire.Application.Interfaces;
using V8Hangfire.Infrastructure.HttpClientAccessors.Interfaces;
using Microsoft.Extensions.Configuration;
using Hangfire;

namespace V8Hangfire.Application.Services
{
    public class V8ClientService : IV8ClientServices
    {
        private readonly IBaseHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private readonly string _apiV8;
        public V8ClientService(IBaseHttpClientFactory baseHttpClient, IConfiguration configuration)
        {
            _clientFactory = baseHttpClient;
            _apiV8 = configuration["V8Domain"];
            _configuration = configuration;
            if (string.IsNullOrWhiteSpace(_apiV8))
            {
                throw new Exception("Not found domain Das Service, please check appsettings config");
            }
        }
        public async Task<bool> JobAsync()
        {
            try
            {
                var apiKey = _configuration.GetValue<string>("SecretKey");
                var client = _clientFactory.Create();
                var apiUrl = "api/Schedule/Schedule-Notification-Destruction-Profile";

                var response = await client.PostAsync(_apiV8, apiUrl, null, null, null, apiKey);

                return response;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public async Task<bool> RecurringJobAsync(string service, string apiUrl)
        {

            try
            {
                var client = _clientFactory.Create();
                var domain = _configuration[service];
                if (string.IsNullOrWhiteSpace(domain))
                {
                    throw new Exception($"Not found domain {service} Service, please check appsettings config");
                }
                var apiKey = _configuration.GetValue<string>("SecretKey");

                var response = await client.GetAsync(domain, apiUrl, null, null, apiKey);
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        [AutomaticRetry(Attempts = 0)]
        [Queue("limited")]
        public async Task<bool> EnqueueJobAsync(string service, string apiUrl, int IdRequest)
        {
            try
            {
                var client = _clientFactory.Create();
                var domain = _configuration[service];
                Parameter param = new Parameter();
                param.IdRequest = IdRequest;
                if (string.IsNullOrWhiteSpace(domain))
                {
                    throw new Exception($"Not found domain {service} Service, please check appsettings config");
                }
                var apiKey = _configuration.GetValue<string>("SecretKey");

                var response = await client.PostAsync(domain, apiUrl, param, null, null, apiKey);
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public class Parameter
        {
            public int IdRequest { get; set; }
        }
    }
}
