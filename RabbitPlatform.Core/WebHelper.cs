#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Core
* 项目描述 ：
* 类 名 称 ：WebHelper
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Core
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/10/30 13:33:28
* 更新时间 ：2019/10/30 13:33:28
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
   public class WebHelper
    {
        #region Session操作
        /// <summary>
        /// 写Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        /// <param name="value">Session的键值</param>
        public static void WriteSession(string key, string value)
        {
            byte[] byteArr = new byte[] { };
            if (value.Length > 0)
            {
                byteArr = Encoding.Default.GetBytes(value);
            }
            HttpContext.Current.Session.Set(key, byteArr);
        }

        /// <summary>
        /// 读取Session的值
        /// </summary>
        /// <param name="key">Session的键名</param>        
        public static string GetSession(string key)
        {
            byte[] byteArr = new byte[] { };
            HttpContext.Current.Session.TryGetValue(key, out byteArr);
            if (byteArr != null && byteArr.Length > 0)
            {
                return Encoding.Default.GetString(byteArr);
            }
            else
            {
                return "";
            }
            //if (key.IsEmpty())
            //    return string.Empty;
            //return HttpContext.Current.Session[key] as string;
            // return "";
        }
        /// <summary>
        /// 删除指定Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        public static void RemoveSession(string key)
        {
            if (key.IsEmpty())
                return;
            HttpContext.Current.Session.Remove(key);
        }

        /// <summary>
        /// 删除Session
        /// </summary>
        /// <param name="key">Session的键名</param>
        public static void RemoveSession()
        {
            HttpContext.Current.Session.Clear();
        }
        #endregion

        #region Cookie操作
        ///// <summary>
        ///// 写cookie值
        ///// </summary>
        ///// <param name="strName">名称</param>
        ///// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpContext.Current.Response.Cookies.Append(strName, strValue);

        }
        ///// <summary>
        ///// 写cookie值
        ///// </summary>
        ///// <param name="strName">名称</param>
        ///// <param name="strValue">值</param>
        ///// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpContext.Current.Response.Cookies.Append(strName, strValue, new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddMinutes(expires) });
        }
        ///// <summary>
        ///// 读cookie值
        ///// </summary>
        ///// <param name="strName">名称</param>
        ///// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                string ss = HttpContext.Current.Request.Cookies[strName].ToString();
                return HttpContext.Current.Request.Cookies[strName].ToString();
            }
            return "";
        }
        ///// <summary>
        ///// 删除Cookie对象
        ///// </summary>
        ///// <param name="CookiesName">Cookie对象名称</param>
        public static void RemoveCookie(string CookiesName)
        {
            HttpContext.Current.Response.Cookies.Delete(CookiesName);
        }
        #endregion
    }
}
