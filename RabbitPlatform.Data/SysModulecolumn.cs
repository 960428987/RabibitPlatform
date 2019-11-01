using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysModulecolumn : IEntity<SysModulecolumn>, ICreationAudited, IModificationAudited
    {
        public string FId { get; set; }
        public string FModuleId { get; set; }
        public string FParentId { get; set; }
        public int? FLayers { get; set; }
        public string FEnCode { get; set; }
        public string FFullName { get; set; }
        public int? FColumnWidth { get; set; }
        public string FColumnAlign { get; set; }
        public string FFormatter { get; set; }
        public short? FIsHide { get; set; }
        public short? FIsExport { get; set; }
        public short? FIsPrint { get; set; }
        public string FExpandJson { get; set; }
        public short? FAllowEdit { get; set; }
        public short? FAllowDelete { get; set; }
        public int? FSortCode { get; set; }
        public short? FDeleteMark { get; set; }
        public short? FEnabledMark { get; set; }
        public string FDescription { get; set; }
        public DateTime? FCreatorTime { get; set; }
        public string FCreatorUserId { get; set; }
        public DateTime? FLastModifyTime { get; set; }
        public string FLastModifyUserId { get; set; }
        public DateTime? FDeleteTime { get; set; }
        public string FDeleteUserId { get; set; }

        public virtual SysModule F { get; set; }
    }
}
