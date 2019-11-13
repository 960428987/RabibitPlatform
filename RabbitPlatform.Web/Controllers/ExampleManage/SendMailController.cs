using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitPlatform.Core;
using RabbitPlatform.Web.App_Start.Handler;

namespace RabbitPlatform.Web.Controllers.ExampleManage
{
    public class SendMailController : MyControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
       // [ValidateInput(false)]
        public ActionResult SendMail(string account, string title, string content)
        {
            MailHelper mail = new MailHelper();
            mail.MailServer = ConfigHelper.Configuration["appseting:MailHost"].ToString();
            mail.MailUserName = ConfigHelper.Configuration["appseting:MailUserName"];
            mail.MailPassword = ConfigHelper.Configuration["appseting:MailPassword"];
            mail.MailName = ConfigHelper.Configuration["appseting:MailName"];
            mail.Send(account, title, content);
            return Success("发送成功。");
        }
    }
}