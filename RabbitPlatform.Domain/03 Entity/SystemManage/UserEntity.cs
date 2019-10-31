#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Domain._03_Entity.SystemManage
* 项目描述 ：
* 类 名 称 ：UserEntity
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Domain._03_Entity.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/10/31 15:29:48
* 更新时间 ：2019/10/31 15:29:48
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Domain.SystemManage
{
    public class UserEntity : IEntity<UserEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string F_Id { get; set; }
        public string F_Account { get; set; }
        public string F_RealName { get; set; }
        public string F_NickName { get; set; }
        public string F_HeadIcon { get; set; }
        public bool? F_Gender { get; set; }
        public DateTime? F_Birthday { get; set; }
        public string F_MobilePhone { get; set; }
        public string F_Email { get; set; }
        public string F_WeChat { get; set; }
        public string F_ManagerId { get; set; }
        public int? F_SecurityLevel { get; set; }
        public string F_Signature { get; set; }
        public string F_OrganizeId { get; set; }
        public string F_DepartmentId { get; set; }
        public string F_RoleId { get; set; }
        public string F_DutyId { get; set; }
        public bool? F_IsAdministrator { get; set; }
        public int? F_SortCode { get; set; }
        public bool? F_DeleteMark { get; set; }
        public bool? F_EnabledMark { get; set; }
        public string F_Description { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_DeleteUserId { get; set; }
    }
}
