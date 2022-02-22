using System.Collections.Generic;
using System.Threading.Tasks;

namespace V8.Application.Interfaces
{
    public interface IAuthorizeService
    {
        Task<bool> CheckPermission(int CodeModule, int[] Permissions);
        Task<List<int>> GetPermissions(int CodeModule);
        Task<List<int>> GetCategoryPermissions(int CodeModule, string CodeType);
        Task<bool> CheckPermissionsMultiModule(int[] CodeModules, int[] Permissions);
        Task<List<int>> GetPermissions(int[] CodeModules);
    }
}
