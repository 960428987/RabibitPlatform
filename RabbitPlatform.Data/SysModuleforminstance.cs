using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysModuleforminstance : IEntity<SysModuleforminstance>, ICreationAudited
    {
        public string FId { get; set; }
        public string FFormId { get; set; }
        public string FObjectId { get; set; }
        public string FInstanceJson { get; set; }
        public int? FSortCode { get; set; }
        public DateTime? FCreatorTime { get; set; }
        public string FCreatorUserId { get; set; }

        public virtual SysModuleform F { get; set; }
    }
}
