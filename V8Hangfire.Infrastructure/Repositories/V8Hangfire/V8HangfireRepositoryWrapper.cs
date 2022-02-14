using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using V8Hangfire.Domain.Interfaces.V8Hangfire;
using V8Hangfire.Infrastructure.Contexts;

namespace V8Hangfire.Infrastructure.Repositories.V8Hangfire
{
    public class V8HangfireRepositoryWrapper : IV8HangfireRepositoryWrapper
    {
        #region ctor

        private readonly V8HangfireContext _repoContext;
        private readonly IConfiguration _configuration;
        public V8HangfireRepositoryWrapper(V8HangfireContext repositoryContext, IConfiguration configuration)
        {
            _repoContext = repositoryContext;
            _configuration = configuration;
        }


        #endregion ctor

        private IJobScheduleRepository _jobSchedule;
        public IJobScheduleRepository JobSchedule
        {
            get
            {
                if (_jobSchedule == null)
                {
                    _jobSchedule = new JobScheduleRepository(_repoContext);
                }
                return _jobSchedule;
            }
        }


        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
