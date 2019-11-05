using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using RabbitPlatform.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitPlatform.Web.App_Start.Handler
{
    public class HandlerLoginAttribute : AuthorizeAttribute,  IAuthorizationFilter
    {
        public bool Ignore = true;
        public HandlerLoginAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (Ignore == false)
            {
                return;
            }
            if (OperatorProvider.Provider.GetCurrent() == null)
            {
                WebHelper.WriteCookie("nfine_login_error", "overdue");
                context.HttpContext.Response.Redirect("/Login/Index");
               // context.HttpContext.Response.Body.Write("<script>top.location.href = '/Login/Index';</script>");
                //context.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
                return;
            }
        }
    }
}
