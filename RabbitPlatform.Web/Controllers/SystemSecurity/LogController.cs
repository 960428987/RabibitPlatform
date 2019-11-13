using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitPlatform.Application.SystemSecurity;
using RabbitPlatform.Core;
using RabbitPlatform.Web.App_Start.Handler;

namespace RabbitPlatform.Web.Controllers.SystemSecurity
{
    public class LogController : MyControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RemoveLog()
        {
            return View();
        }
        private LogApp logApp = new LogApp();

        
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = logApp.GetList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRemoveLog(string keepTime)
        {
            logApp.RemoveLog(keepTime);
            return Success("清空成功。");
        }
    }
}