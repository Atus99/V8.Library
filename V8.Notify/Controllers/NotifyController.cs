using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V8.Notify.Constants;
using V8.Notify.CustomHub;
using V8Notify.Application.Interfaces;
using V8Notify.Application.Models;

namespace V8.Notify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly Func<string, IHubNotifyHelper> _hubNotificationHelper;
        private readonly INotificationService _notification;
        public NotifyController(Func<string, IHubNotifyHelper> hubNotificationHelper, INotificationService notification)
        {
            _hubNotificationHelper = hubNotificationHelper;
            _notification = notification;
        }

        [HttpPost]
        [Route("PushToUser")]
        public async Task<IActionResult> PushToUser([FromForm] int userId)
        {
            await _hubNotificationHelper(MutipleImplement.HubNotifyHelperType.V8Web.ToString()).PushToUser(userId);
            return new OkResult();
        }

        [HttpPost]
        [Route("PushToUsers")]
        public async Task<IActionResult> PushToUsers(VMSendNotification model)
        {
            await _notification.PushToUsers(model);
            await _hubNotificationHelper(MutipleImplement.HubNotifyHelperType.V8Web.ToString()).PushToUsers(model.idsUser);
            return new OkResult();
        }
    }
}
