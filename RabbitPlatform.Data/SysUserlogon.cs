using System;
using System.Collections.Generic;

namespace RabbitPlatform.Data
{
    public partial class SysUserlogon
    {
        public string FId { get; set; }
        public string FUserId { get; set; }
        public string FUserPassword { get; set; }
        public string FUserSecretkey { get; set; }
        public DateTime? FAllowStartTime { get; set; }
        public DateTime? FAllowEndTime { get; set; }
        public DateTime? FLockStartDate { get; set; }
        public DateTime? FLockEndDate { get; set; }
        public DateTime? FFirstVisitTime { get; set; }
        public DateTime? FPreviousVisitTime { get; set; }
        public DateTime? FLastVisitTime { get; set; }
        public DateTime? FChangePasswordDate { get; set; }
        public bool? FMultiUserLogin { get; set; }
        public int? FLogOnCount { get; set; }
        public bool? FUserOnLine { get; set; }
        public string FQuestion { get; set; }
        public string FAnswerQuestion { get; set; }
        public bool? FCheckIpaddress { get; set; }
        public string FLanguage { get; set; }
        public string FTheme { get; set; }
    }
}
