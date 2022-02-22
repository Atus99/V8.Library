using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V8.Application.Enums;
using V8.Web.Attributes;

namespace V8.Web.Controllers.Controller_System
{
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class GroupPermissionController : BaseController
    {
        // quyền
        [HasPermission((int)EnumModule.Code.S9030, new int[] { (int)EnumPermission.Type.Read })]
        public IActionResult Index()
        {
            return View();
        }
    }
}
