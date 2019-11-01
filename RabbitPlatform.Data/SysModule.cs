using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysModule : IEntity<SysModule>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string FId { get; set; }
        public string FParentId { get; set; }
        public int? FLayers { get; set; }
        public string FEnCode { get; set; }
        public string FFullName { get; set; }
        public string FIcon { get; set; }
        public string FUrlAddress { get; set; }
        public string FTarget { get; set; }
        public bool? FIsMenu { get; set; }
        public bool? FIsExpand { get; set; }
        public bool? FIsPublic { get; set; }
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

        public virtual SysModulecolumn SysModulecolumn { get; set; }
        public virtual SysModuleform SysModuleform { get; set; }
    }
}
