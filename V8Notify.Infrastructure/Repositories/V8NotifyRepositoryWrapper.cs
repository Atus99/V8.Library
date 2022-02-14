using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V8Notify.Domain.Interfaces;
using V8Notify.Infrastructure.Contexts;

namespace V8Notify.Infrastructure.Repositories
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
