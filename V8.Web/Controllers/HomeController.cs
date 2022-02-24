using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using V8.Application.Constants;
using V8.Application.Enums;
using V8.Application.Interfaces;
using V8.Application.Models.CustomModels;
using V8.Application.Models.ViewModels;
using V8.Web.Models;

namespace V8.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeServices _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeServices homeServices)
        {
            _logger = logger;
            _homeService = homeServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Notification
        [HttpPost]
        public async Task<IActionResult> HeaderNotification(NotificationCondition condition)
        {
            HeaderNotification noti = await _homeService.GetHeaderNotification(condition);
            return PartialView("_HeaderNotification", noti);
        }

        public async Task<IActionResult> ListNotification(NotificationCondition condition)
        {
            PaginatedList<VMNotification> noti = await _homeService.GetListNotificationPaging(condition);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchNotificationPaging(NotificationCondition condition)
        {
            ViewBag.Keyword = condition.Keyword;
            if (condition.Status > 0)
            {
                if (condition.Status == (int)EnumStatusNotification.Status.Unread)
                {
                    condition.NotiStatus = false;
                }
                else
                {
                    condition.NotiStatus = true;
                }
            }
            PaginatedList<VMNotification> noti = await _homeService.GetListNotificationPaging(condition);
            ViewBag.StatusNoti = condition.Status;
            return PartialView("_ListNotification", noti);
        }

        [HttpPost]
        public async Task<IActionResult> ReadNotification(int id)
        {
            bool isSuccess = await _homeService.ReadNotification(id);
            ServiceResult rs = new ServiceResult();
            if (isSuccess)
            {
                rs.Code = CommonConst.Success;
            }
            else
            {
                rs.Code = CommonConst.Error;
            }

            return CustJSonResult(rs);
        }

        [HttpPost]
        public async Task<IActionResult> ReadAllNotification()
        {
            bool isSuccess = await _homeService.ReadAllNotification();
            ServiceResult rs = new ServiceResult();
            if (isSuccess)
            {
                rs.Code = CommonConst.Success;
            }
            else
            {
                rs.Code = CommonConst.Error;
            }

            return CustJSonResult(rs);
        }
        #endregion
    }
}
