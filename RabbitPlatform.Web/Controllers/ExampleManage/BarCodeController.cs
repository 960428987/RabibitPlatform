using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RabbitPlatform.Web.Controllers.ExampleManage
{
    public class BarCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}