using System.Threading.Tasks;

namespace V8Hangfire.Application.Interfaces
{
    public interface IScheduleServices
    {
        Task<bool> UpdateOrAddJob(string jobCode, string service, string apiUrl, string cronString);
        Task<bool> AddEnqueueJob(string service, string apiUrl, int IdRequest);
    }
}
