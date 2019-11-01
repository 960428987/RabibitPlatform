using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysRoleauthorize : IEntity<SysRoleauthorize>
    {
        public string FId { get; set; }
        public int? FItemType { get; set; }
        public string FItemId { get; set; }
        public int? FObjectType { get; set; }
        public string FObjectId { get; set; }
        public int? FSortCode { get; set; }
        public DateTime? FCreatorTime { get; set; }
        public string FCreatorUserId { get; set; }
    }
}
