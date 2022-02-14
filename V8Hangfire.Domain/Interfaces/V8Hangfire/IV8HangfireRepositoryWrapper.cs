using System.Threading.Tasks;

namespace V8Hangfire.Domain.Interfaces.V8Hangfire
{
    public interface IV8HangfireRepositoryWrapper
    {
        IJobScheduleRepository JobSchedule { get; }
        Task SaveAsync();
    }
}
