using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysModuleapp : IEntity<SysModuleapp>
    {
        public string Id { get; set; }
        public string AppCode { get; set; }
        public string AppName { get; set; }
        public int? SortCode { get; set; }
        public int? DeleteMark { get; set; }
        public int? EnabledMark { get; set; }
        public string Description { get; set; }
        public DateTime? CreatorTime { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string LastModifyUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string DeleteUserId { get; set; }
    }
}
