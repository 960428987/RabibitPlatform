#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Domain._03_Entity.SystemSecurity
* 项目描述 ：
* 类 名 称 ：LogEntity
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Domain._03_Entity.SystemSecurity
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/10/31 14:20:19
* 更新时间 ：2019/10/31 14:20:19
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Domain.SystemSecurity
{
    public class LogEntity : IEntity<LogEntity>, ICreationAudited
    {
        public string F_Id { get; set; }
        public DateTime? F_Date { get; set; }
        public string F_Account { get; set; }
        public string F_NickName { get; set; }
        public string F_Type { get; set; }
        public string F_IPAddress { get; set; }
        public string F_IPAddressName { get; set; }
        public string F_ModuleId { get; set; }
        public string F_ModuleName { get; set; }
        public bool? F_Result { get; set; }
        public string F_Description { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
    }
}
