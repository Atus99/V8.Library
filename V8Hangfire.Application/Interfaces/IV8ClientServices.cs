using System.Threading.Tasks;

namespace V8Hangfire.Application.Interfaces
{
    public interface IV8ClientServices
    {
        Task<bool> JobAsync();
        Task<bool> RecurringJobAsync(string service, string apiUrl);
        Task<bool> EnqueueJobAsync(string service, string apiUrl, int IdRequest);
    }
}
