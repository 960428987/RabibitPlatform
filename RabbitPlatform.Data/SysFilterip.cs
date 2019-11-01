using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysFilterip : IEntity<SysFilterip>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string FId { get; set; }
        public bool? FType { get; set; }
        public string FStartIp { get; set; }
        public string FEndIp { get; set; }
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
