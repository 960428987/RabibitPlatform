using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitPlatform.Application.SystemSecurity;
using RabbitPlatform.Web.App_Start.Handler;
using RabbitPlatform.Data;
using RabbitPlatform.Core;
namespace RabbitPlatform.Web.Controllers.SystemSecurity
{
    public class FilterIPController : MyControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        private FilterIPApp filterIPApp = new FilterIPApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            var data = filterIPApp.GetList(keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = filterIPApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SysFilterip filterIPEntity, string keyValue)
        {
            filterIPApp.SubmitForm(filterIPEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            filterIPApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}