using System.Collections.Generic;
using System.Threading.Tasks;

namespace V8.Notify.CustomHub
{
    public interface IHubNotifyHelper
    {
        IEnumerable<int> GetOnlineUser();
        Task PushToUser(int userId);
        Task PushToUsers(int[] userIds);
        Task PushToAll();
    }
}
