#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Core.Operator
* 项目描述 ：
* 类 名 称 ：OperatorProvider
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Core.Operator
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/10/31 14:33:39
* 更新时间 ：2019/10/31 14:33:39
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Core
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }
        private string LoginUserKey = "nfine_loginuserkey_2016";
        private string LoginProvider = ConfigHelper.Configuration["appseting:LoginProvider"];

        public OperatorModel GetCurrent()
        {
            OperatorModel operatorModel = new OperatorModel();
            if (LoginProvider == "Cookie")
            {
                operatorModel = DESEncrypt.Decrypt(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<OperatorModel>();
            }
            else
            {
                operatorModel = DESEncrypt.Decrypt(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<OperatorModel>();
            }
            return operatorModel;
        }
        public void AddCurrent(OperatorModel operatorModel)
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.WriteCookie(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()), 60);
            }
            else
            {
                WebHelper.WriteSession(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()));
            }
            WebHelper.WriteCookie("nfine_mac", Md5.md5(Net.GetMacByNetworkInterface().ToJson(), 32));
            WebHelper.WriteCookie("nfine_licence", Licence.GetLicence());
        }
        public void RemoveCurrent()
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.RemoveCookie(LoginUserKey.Trim());
            }
            else
            {
                WebHelper.RemoveSession(LoginUserKey.Trim());
            }
        }
    }
}
