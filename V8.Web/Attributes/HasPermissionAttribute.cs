using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace V8.Web.Attributes
{
    public class HasPermissionAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        /// <summary>
        /// Permission string to get from controller
        /// </summary>
        public readonly int[] Permissions;
        /// <summary>
        /// CodeModule
        /// </summary>
        public readonly int CodeModule;
        /// <summary>
        /// Code modules string to get from controller
        /// </summary>
        public readonly int[] CodeModules;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="codeModule"></param>
        /// <param name="permission"></param>
        public HasPermissionAttribute(int codeModule, int[] permission)
        {
            CodeModule = codeModule;
            Permissions = permission;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="codeModules"></param>
        /// <param name="permission"></param>
        public HasPermissionAttribute(int[] codeModules, int[] permission)
        {
            CodeModules = codeModules;
            Permissions = permission;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            return;
        }
    }
}
