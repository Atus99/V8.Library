using System.Threading.Tasks;
using V8.Application.Interfaces;

namespace V8.Application.Services
{
    public class IPAddressClientService : IIPAddressClientServices
    {
        private readonly IHttpClientService _httpClientService;

        public IPAddressClientService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async Task<bool> GetPublicIPAddress()
        {
            var apiAddress = "http://api.ipify.org";
            var apiUrl = "?format=json";
            var rs = await _httpClientService.GetAsync<IpValue>(apiAddress, apiUrl);
            return true;
        }
    }
    public class IpValue
    {
        public string IP { get; set; }
    }
}
