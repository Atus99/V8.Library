using V8Hangfire.Domain.Interfaces.V8Hangfire;
using V8Hangfire.Domain.Models.V8Hangfire;
using V8Hangfire.Infrastructure.Contexts;

namespace V8Hangfire.Infrastructure.Repositories.V8Hangfire
{
    public class JobScheduleRepository : BaseRepository<JobSchedule>, IJobScheduleRepository
    {
        public JobScheduleRepository(V8HangfireContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
