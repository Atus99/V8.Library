using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using V8.Application.Interfaces;

namespace V8.Application.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IConfiguration _configuration;
        public AuthorizeService(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<bool> CheckPermission(int CodeModule, int[] Permissions)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckPermissionsMultiModule(int[] CodeModules, int[] Permissions)
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> GetCategoryPermissions(int CodeModule, string CodeType)
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> GetPermissions(int CodeModule)
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> GetPermissions(int[] CodeModules)
        {
            throw new NotImplementedException();
        }
    }
}
