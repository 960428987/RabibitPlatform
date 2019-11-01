using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysDbbackup : IEntity<SysDbbackup>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string FId { get; set; }
        public string FBackupType { get; set; }
        public string FDbName { get; set; }
        public string FFileName { get; set; }
        public string FFileSize { get; set; }
        public string FFilePath { get; set; }
        public DateTime? FBackupTime { get; set; }
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
