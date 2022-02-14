using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V8.Notify.Constants;

namespace V8.Notify.CustomHub.WebHub
{
    public class HubNotifyHelper : IHubNotifyHelper
    {
        IHubContext<NotifyHub> _hubContext { get; }
        // private readonly IConnectionManager _connectionManager;
        private readonly Func<string, IConnectionManager> _connectionManager;
        public HubNotifyHelper(Func<string, IConnectionManager> connectionManager, IHubContext<NotifyHub> hubContext)
        {
            _connectionManager = connectionManager;
            _hubContext = hubContext;
        }

        public IEnumerable<int> GetOnlineUser()
        {
            return _connectionManager(MutipleImplement.ConnectionManagerType.V8Web.ToString()).OnlineUsers;
        }

        /// <summary>
        /// Gọi tới action load notification của user
        /// </summary>
        /// <param name="userId">id người dùng cần load lại notification</param>
        /// <returns></returns>
        public async Task PushToUser(int userId)
        {
            HashSet<string> connections = _connectionManager(MutipleImplement.ConnectionManagerType.V8Web.ToString()).GetConnections(userId);

            if (connections != null && connections.Count != 0)
            {
                foreach (var connection in connections)
                {
                    await _hubContext.Clients.Client(connection).SendAsync("LoadNotifyByUserId", userId);
                }
            }
        }

        /// <summary>
        /// Gọi tới action load notification của nhiều user
        /// </summary>
        /// <param name="userIds">id những người dùng cần load lại notification</param>
        /// <returns></returns>
        public async Task PushToUsers(int[] userIds)
        {
            for (int i = 0; i < userIds.Length; i++)
            {
                await PushToUser(userIds[i]);
            }
        }

        /// <summary>
        /// Load lại all notification của tất cả người dùng đang online
        /// </summary>
        public async Task PushToAll()
        {
            await _hubContext.Clients.All.SendAsync("LoadNotifyByUserId");
        }
    }
}
