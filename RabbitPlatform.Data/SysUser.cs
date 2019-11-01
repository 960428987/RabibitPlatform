using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysUser : IEntity<SysUser>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string FId { get; set; }
        public string FAccount { get; set; }
        public string FRealName { get; set; }
        public string FNickName { get; set; }
        public string FHeadIcon { get; set; }
        public bool? FGender { get; set; }
        public DateTime? FBirthday { get; set; }
        public string FMobilePhone { get; set; }
        public string FEmail { get; set; }
        public string FWeChat { get; set; }
        public string FManagerId { get; set; }
        public int? FSecurityLevel { get; set; }
        public string FSignature { get; set; }
        public string FOrganizeId { get; set; }
        public string FDepartmentId { get; set; }
        public string FRoleId { get; set; }
        public string FDutyId { get; set; }
        public bool? FIsAdministrator { get; set; }
        public int? FSortCode { get; set; }
        public bool? FDeleteMark { get; set; }
        public bool? FEnabledMark { get; set; }
        public string FDescription { get; set; }
        public DateTime? FCreatorTime { get; set; }
        public string FCreatorUserId { get; set; }
        public DateTime? FLastModifyTime { get; set; }
        public string FLastModifyUserId { get; set; }
        public DateTime? FDeleteTime { get; set; }
        public string FDeleteUserId { get; set; }
    }
}
