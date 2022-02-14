using System;
using System.Collections.Generic;
using System.Text;
using V8Notify.Domain.Interfaces;

namespace V8Notify.Application.Services
{
    public class BaseMasterService
    {
        protected IV8NotifyRepositoryWrapper _v8NotifyRepo;
        public BaseMasterService(IV8NotifyRepositoryWrapper dasNotifyRepository)
        {
            _v8NotifyRepo = dasNotifyRepository;
        }
    }
}
