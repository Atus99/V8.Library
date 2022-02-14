using V8Hangfire.Domain.Interfaces.V8Hangfire;

namespace V8Hangfire.Application.Services
{
    public class BaseMasterService
    {
        protected IV8HangfireRepositoryWrapper _v8HangfireRepo;


        public BaseMasterService(IV8HangfireRepositoryWrapper v8Repository)
        {
            _v8HangfireRepo = v8Repository;
        }
    }
}
