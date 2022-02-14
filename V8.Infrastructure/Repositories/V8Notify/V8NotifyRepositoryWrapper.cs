using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V8.Domain.Interfaces.V8Notify;
using V8.Infrastructure.Contexts;

namespace V8.Infrastructure.Repositories.V8Notify
{
    public class V8NotifyRepositoryWrapper : IV8NotifyRepositoryWrapper
    {
        #region ctor
        private readonly V8NotifyContext _repoContext;

        public V8NotifyRepositoryWrapper(V8NotifyContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        #endregion

        #region properties
        private INotificationRepository _notification;

        public INotificationRepository Notification
        {
            get
            {
                if (_notification == null)
                {
                    _notification = new NotificationRepository(_repoContext);
                }
                return _notification;
            }
        }

        #endregion

        public async Task SaveAync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
