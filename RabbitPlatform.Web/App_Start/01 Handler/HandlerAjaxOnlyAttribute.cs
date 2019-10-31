using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitPlatform.Web
{
    public class HandlerAjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public bool Ignore { get; set; }
        public HandlerAjaxOnlyAttribute(bool ignore = false)
        {
            Ignore = ignore;
        }
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            if (Ignore)
            {
                return true;
            }
            else
            {
                //if (routeContext.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest")
                //{//是ajax请求
                //    return true;
                //}
                //else
                //{//不是ajax请求

                //}
                return routeContext.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
            }
        }
    }
}
