using System.Threading.Tasks;
using V8Notify.Application.Models;
using V8Notify.Application.Models.CustomModels;
using V8Notify.Domain.Models.Notify;

namespace V8Notify.Application.Interfaces
{
    public interface INotificationService : IBaseMasterService<Notification>
    {
        Task<ServiceResult> PushToUsers(VMSendNotification model);
    }
}
