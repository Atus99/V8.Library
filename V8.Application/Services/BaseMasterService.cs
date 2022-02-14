using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using V8.Domain.Interfaces.V8;
using V8.Domain.Interfaces.V8Notify;

namespace V8.Application.Services
{
    public class BaseMasterService
    {
        protected IV8RepositoryWrapper _v8Repo;
        protected IV8NotifyRepositoryWrapper _v8NotifyRepo;

        public BaseMasterService(IV8RepositoryWrapper v8Repository)
        {
            _v8Repo = v8Repository;
        }

        public BaseMasterService(IV8RepositoryWrapper v8Repository, IV8NotifyRepositoryWrapper v8NotifyRepository)
        {
            _v8Repo = v8Repository;
            _v8NotifyRepo = v8NotifyRepository;
        }

        public BaseMasterService(IV8NotifyRepositoryWrapper v8NotifyRepository)
        {
            _v8NotifyRepo = v8NotifyRepository;
        }
    }
}
