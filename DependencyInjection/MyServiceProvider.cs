#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：DependencyInjection
* 项目描述 ：
* 类 名 称 ：MyServiceProvider
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：DependencyInjection
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/8 16:54:02
* 更新时间 ：2019/11/8 16:54:02
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public static class MyServiceProvider
    {
        public static IServiceProvider ServiceProvider
        {
            get; set;
        }
    }
}
