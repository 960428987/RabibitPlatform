using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysModuleform : IEntity<SysModuleform>, ICreationAudited
    {
        public string FId { get; set; }
        public string FModuleId { get; set; }
        public string FEnCode { get; set; }
        public string FFullName { get; set; }
        public string FFormJson { get; set; }
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
        public virtual SysModuleforminstance SysModuleforminstance { get; set; }
    }
}
