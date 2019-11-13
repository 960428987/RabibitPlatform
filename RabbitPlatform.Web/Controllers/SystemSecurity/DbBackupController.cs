using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitPlatform.Web.App_Start.Handler;
using RabbitPlatform.Data;
using RabbitPlatform.Application.SystemSecurity;
using RabbitPlatform.Core;
using Microsoft.AspNetCore.Hosting.Internal;
using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
namespace RabbitPlatform.Web.Controllers.SystemSecurity
{
    public class DbBackupController : MyControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        private DbBackupApp dbBackupApp = new DbBackupApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string queryJson)
        {
            var data = dbBackupApp.GetList(queryJson);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SysDbbackup dbBackupEntity)
        {
            dbBackupEntity.FFilePath = MyServiceProvider.ServiceProvider.GetRequiredService<HostingEnvironment>().WebRootPath + "\\Resource\\DbBackup\\"  + dbBackupEntity.FFileName + ".bak";
            dbBackupEntity.FFileName = dbBackupEntity.FFileName + ".bak";
            dbBackupApp.SubmitForm(dbBackupEntity);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            dbBackupApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
        [HttpPost]
        [HandlerAuthorize]
        public void DownloadBackup(string keyValue)
        {
            var data = dbBackupApp.GetForm(keyValue);
            string filename = data.FFileName;
            string filepath = MyServiceProvider.ServiceProvider.GetRequiredService<HostingEnvironment>().WebRootPath+"\\"  + data.FFilePath;
            if (FileDownHelper.FileExists(filepath))
            {
                FileDownHelper.DownLoadold(filepath, filename);
            }
        }
    }
}