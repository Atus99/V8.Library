using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace V8.Notify.CustomHub
{
    public interface IConnectionManager
    {
        void AddConnection(int userId, string connectionID);
        void RemoveConnection(string connectionId);
        HashSet<string> GetConnections(int userId);
        IEnumerable<int> OnlineUsers { get; }
    }
}
