using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysOrganize : IEntity<SysOrganize>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string FId { get; set; }
        public string FParentId { get; set; }
        public int? FLayers { get; set; }
        public string FEnCode { get; set; }
        public string FFullName { get; set; }
        public string FShortName { get; set; }
        public string FCategoryId { get; set; }
        public string FManagerId { get; set; }
        public string FTelePhone { get; set; }
        public string FMobilePhone { get; set; }
        public string FWeChat { get; set; }
        public string FFax { get; set; }
        public string FEmail { get; set; }
        public string FAreaId { get; set; }
        public string FAddress { get; set; }
        public bool? FAllowEdit { get; set; }
        public bool? FAllowDelete { get; set; }
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
