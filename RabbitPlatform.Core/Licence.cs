#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Core
* 项目描述 ：
* 类 名 称 ：Licence
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Core
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/10/31 14:55:26
* 更新时间 ：2019/10/31 14:55:26
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Core
{
    public sealed class Licence
    {
        public static bool IsLicence(string key)
        {
            // string host = HttpContext.Current.Request.Url.Host.ToLower();
            string host = HttpContext.Current.Connection.RemoteIpAddress.ToString().ToLower();
            if (host.Equals("localhost"))
                return true;
            string licence = ConfigHelper.Configuration["appseting:LicenceKey"];
            if (licence != null && licence == Md5.md5(key, 32))
                return true;

            return false;
        }
        public static string GetLicence()
        {
            var licence =ConfigHelper.Configuration["appseting:LicenceKey"];
            if (string.IsNullOrEmpty(licence))
            {
                licence = Common.GuId();
                ConfigHelper.Configuration["appseting:LicenceKey"] = licence;
            }
            return Md5.md5(licence, 32);
        }
    }
}
