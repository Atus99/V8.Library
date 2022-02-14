using V8Notify.Domain.Interfaces;
using V8Notify.Domain.Models.Notify;
using V8Notify.Infrastructure.Contexts;

namespace V8Notify.Infrastructure.Repositories
{
    public class NotificationRepository : V8NotifyBaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(V8NotifyContext repositoryContext)
            : base(repositoryContext)
        {
        }

    }

}
