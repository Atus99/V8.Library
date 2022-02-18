using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V8.Application.Constants;
using V8.Application.Models.CustomModels;

namespace V8.Web.Controllers
{
    public class BaseController : Controller
    {
        private string _title;
        #region Form Data
        private Hashtable _data;
        protected Hashtable DATA
        {
            get
            {
                if (Equals(_data, null))
                {
                    _data = GetPostData();
                }
                return _data;
            }
        }
        #endregion

        #region Functions
        private Hashtable GetPostData()
        {
            var data = new Hashtable();
            try
            {
                foreach (string key in Request.Query.Keys)
                {
                    if (!data.ContainsKey(key))
                    {
                        data.Add(key, Request.Query[key]);
                    }
                }
            }
            catch { }

            try
            {
                foreach (string key in Request.Form.Keys)
                {
                    if (!data.ContainsKey(key))
                    {
                        data.Add(key, Request.Form[key].ToString());
                    }
                }
            }
            catch { }

            return data;
        }
        #endregion

        protected void SetTitle(string title)
        {
            _title = title;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (!Equals(_title, null))
            {
                ViewData["Title"] = _title;
            }

            IServiceProvider services = filterContext.HttpContext.RequestServices;
            //var userPrincipalService = (IUserPrincipalService)services.GetService(typeof(IUserPrincipalService));
            var configuration = (IConfiguration)services.GetService(typeof(IConfiguration));
            ViewBag.NotifyUrl = configuration["NotifyDomain"];

            //Lưu userid ở layout
            ViewBag.LayoutUserId = 1; //userPrincipalService.UserId;
        }

        /// <summary>
        /// Trả về JSon file theo kết quả Service trả về
        /// </summary>
        /// <param name="ServiceResult"></param>
        /// <returns></returns>
        protected IActionResult CustJSonResult(ServiceResult ServiceResult)
        {
            if (ServiceResult.Code == CommonConst.Success)
            {
                return JSSuccessResult(ServiceResult.Message, ServiceResult.Data);
            }
            else if (ServiceResult.Code == CommonConst.Error)
            {
                return JSErrorResult(ServiceResult.Message, ServiceResult.Data);
            }
            else if (ServiceResult.Code == CommonConst.Warning)
            {
                return JSWarningResult(ServiceResult.Message, ServiceResult.Data);
            }
            else if (ServiceResult.Code == CommonConst.Redirect)
            {
                return JSRedirect(ServiceResult.Message);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Trả về JSon Code Success
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected IActionResult JSSuccessResult(string msg)
        {
            return new JsonResult(new
            {
                Type = CommonConst.Success,
                Message = msg
            });
        }

        /// <summary>
        /// Trả về JSon Code Success
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        protected IActionResult JSSuccessResult<T>(string msg, T val)
        {
            return new JsonResult(new
            {
                Type = CommonConst.Success,
                Message = msg,
                Data = val
            });
        }

        /// <summary>
        /// Trả về JSon Code Error
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected IActionResult JSErrorResult(string msg)
        {
            return new JsonResult(new
            {
                Type = CommonConst.Error,
                Message = msg
            });
        }

        /// <summary>
        /// Trả về JSon Code Error
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        protected IActionResult JSErrorResult<T>(string msg, T val)
        {
            return new JsonResult(new
            {
                Type = CommonConst.Error,
                Message = msg,
                Data = val
            });
        }

        /// <summary>
        /// Trả về JSon Code Warning
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected IActionResult JSWarningResult(string msg)
        {
            return new JsonResult(new
            {
                Type = CommonConst.Warning,
                Message = msg
            });
        }

        /// <summary>
        /// Trả về JSon Code Warning
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        protected IActionResult JSWarningResult<T>(string msg, T val)
        {
            return new JsonResult(new
            {
                Type = CommonConst.Warning,
                Message = msg,
                Data = val
            });
        }

        /// <summary>
        /// Trả về JSon Redirect
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        protected IActionResult JSRedirect(string url)
        {
            return new JsonResult(new
            {
                Type = CommonConst.Redirect,
                Message = url
            });
        }
    }
}
