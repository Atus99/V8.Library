
using V8Notify.Domain.Interfaces;

namespace V8Notify.Application.Services
{
    public class BaseMasterService
    {
        protected IV8NotifyRepositoryWrapper _v8NotifyRepo;
        public BaseMasterService(IV8NotifyRepositoryWrapper v8NotifyRepository)
        {
            _v8NotifyRepo = v8NotifyRepository;
        }
    }
}
