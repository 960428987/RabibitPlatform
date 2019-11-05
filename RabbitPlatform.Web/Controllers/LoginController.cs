using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitPlatform.Application;
using RabbitPlatform.Application.SystemManage;
using RabbitPlatform.Core;
using RabbitPlatform.Data;
using RabbitPlatform.Application.SystemSecurity;
namespace RabbitPlatform.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        [HttpGet]
        public ActionResult OutLogin()
        {
            new LogApp().WriteDbLog(new SysLog
            {
                FModuleName = "系统登录",
                FType = DbLogType.Exit.ToString(),
                FAccount = OperatorProvider.Provider.GetCurrent().UserCode,
                FNickName = OperatorProvider.Provider.GetCurrent().UserName,
                FResult = true,
                FDescription = "安全退出系统",
            });
            WebHelper.RemoveSession();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            SysLog logEntity = new SysLog();
            logEntity.FModuleName = "系统登录";
            logEntity.FType = DbLogType.Login.ToString();
            try
            {
                if (WebHelper.GetSession("nfine_session_verifycode").IsEmpty() || Md5.md5(code.ToLower(), 16) != WebHelper.GetSession("nfine_session_verifycode").ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }

                SysUser userEntity = new UserApp().CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.FId;
                    operatorModel.UserCode = userEntity.FAccount;
                    operatorModel.UserName = userEntity.FRealName;
                    operatorModel.CompanyId = userEntity.FOrganizeId;
                    operatorModel.DepartmentId = userEntity.FDepartmentId;
                    operatorModel.RoleId = userEntity.FRoleId;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    if (userEntity.FAccount == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logEntity.FAccount = userEntity.FAccount;
                    logEntity.FNickName = userEntity.FRealName;
                    logEntity.FResult = true;
                    logEntity.FDescription = "登录成功";
                    new LogApp().WriteDbLog(logEntity);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                logEntity.FAccount = username;
                logEntity.FNickName = username;
                logEntity.FResult = false;
                logEntity.FDescription = "登录失败，" + ex.Message;
                new LogApp().WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}