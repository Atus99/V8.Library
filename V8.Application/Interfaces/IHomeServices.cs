using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V8.Application.Models.ViewModels;

namespace V8.Application.Interfaces
{
    public interface IHomeServices
    {
        Task<PaginatedList<VMNotification>> GetListNotificationPaging(NotificationCondition condition);
        Task<HeaderNotification> GetHeaderNotification(NotificationCondition condition);
        //Task<int> TotalUnreadNotification();
        Task<bool> ReadNotification(int id);
        Task<bool> ReadAllNotification();
    }
}
