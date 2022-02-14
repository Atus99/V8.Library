using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V8.Notify.Constants;

namespace V8.Notify.CustomHub.WebHub
{
    public class NotifyHub : Hub
    {
        // private IConnectionManager _connectionManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Func<string, IConnectionManager> _connectionManager;
        public NotifyHub(Func<string, IConnectionManager> connectionManager, IHttpContextAccessor httpContextAccessor)
        {
            _connectionManager = connectionManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public override Task OnConnectedAsync()
        {
            var userId = _httpContextAccessor.HttpContext.Request.Query["userid"];

            //Get UserId from client
            int intUserId;
            var bnlRs = int.TryParse(userId, out intUserId);
            if (bnlRs)
            {
                _connectionManager(MutipleImplement.ConnectionManagerType.V8Web.ToString()).AddConnection(intUserId, Context.ConnectionId);
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _connectionManager(MutipleImplement.ConnectionManagerType.V8Web.ToString()).RemoveConnection(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// Example, nếu cần thì viết hàm  để gọi
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendAll(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
