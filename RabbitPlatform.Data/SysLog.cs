using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysLog : IEntity<SysLog>, ICreationAudited
    {
        public string FId { get; set; }
        public DateTime? FDate { get; set; }
        public string FAccount { get; set; }
        public string FNickName { get; set; }
        public string FType { get; set; }
        public string FIpaddress { get; set; }
        public string FIpaddressName { get; set; }
        public string FModuleId { get; set; }
        public string FModuleName { get; set; }
        public bool? FResult { get; set; }
        public string FDescription { get; set; }
        public DateTime? FCreatorTime { get; set; }
        public string FCreatorUserId { get; set; }
    }
}
