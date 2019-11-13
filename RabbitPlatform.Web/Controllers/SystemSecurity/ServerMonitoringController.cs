using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitPlatform.Web.App_Start.Handler;
namespace RabbitPlatform.Web.Controllers.SystemSecurity
{
    public class ServerMonitoringController : MyControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}