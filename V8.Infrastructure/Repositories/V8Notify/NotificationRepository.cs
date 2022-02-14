using System;
using System.Collections.Generic;
using System.Text;
using V8.Domain.Interfaces.V8Notify;
using V8.Domain.Models.V8Notify;
using V8.Infrastructure.Contexts;

namespace V8.Infrastructure.Repositories.V8Notify
{
    public class NotificationRepository : V8NotifyBaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(V8NotifyContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
