#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Domain._01_Infrastructure
* 项目描述 ：
* 类 名 称 ：IDeleteAudited
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Domain._01_Infrastructure
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/10/31 14:25:28
* 更新时间 ：2019/10/31 14:25:28
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Domain
{ 
    public interface IDeleteAudited
    {
        /// <summary>
        /// 逻辑删除标记
        /// </summary>
        bool? F_DeleteMark { get; set; }

        /// <summary>
        /// 删除实体的用户
        /// </summary>
        string F_DeleteUserId { get; set; }

        /// <summary>
        /// 删除实体时间
        /// </summary>
        DateTime? F_DeleteTime { get; set; }
    }
}
