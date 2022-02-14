using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V8.Domain.Interfaces.V8;
using V8.Infrastructure.Contexts;

namespace V8.Infrastructure.Repositories.V8
{
    public class V8RepositoryWrapper : IV8RepositoryWrapper
    {
        private readonly V8Context _repoContext;
        private readonly IConfiguration _configuration;
        public V8RepositoryWrapper(V8Context repositoryContext, IConfiguration configuration)
        {
            _repoContext = repositoryContext;
            _configuration = configuration;
        }

        #region Properties V8
        private IUserRepository _user;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        #endregion

        public async Task SaveAync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
