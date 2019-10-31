#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Application._01_Infrastructure
* 项目描述 ：
* 类 名 称 ：DbLogType
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Application._01_Infrastructure
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/10/31 15:26:00
* 更新时间 ：2019/10/31 15:26:00
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RabbitPlatform.Application
{
    public enum DbLogType
    {
        [Description("其他")]
        Other = 0,
        [Description("登录")]
        Login = 1,
        [Description("退出")]
        Exit = 2,
        [Description("访问")]
        Visit = 3,
        [Description("新增")]
        Create = 4,
        [Description("删除")]
        Delete = 5,
        [Description("修改")]
        Update = 6,
        [Description("提交")]
        Submit = 7,
        [Description("异常")]
        Exception = 8,
    }
}
