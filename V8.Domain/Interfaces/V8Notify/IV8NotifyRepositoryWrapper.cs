using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace V8.Domain.Interfaces.V8Notify
{
    public interface IV8NotifyRepositoryWrapper
    {
        INotificationRepository Notification { get; }
        Task SaveAync();
    }
}
