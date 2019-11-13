using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RabbitPlatform.Web.Controllers.ReportManage
{
    public class EchartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}