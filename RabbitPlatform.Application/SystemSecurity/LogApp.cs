#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Application.SystemSecurity
* 项目描述 ：
* 类 名 称 ：LogApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Application.SystemSecurity
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/1 16:37:47
* 更新时间 ：2019/11/1 16:37:47
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using RabbitPlatform.Core;
using RabbitPlatform.Data;
using RabbitPlatform.Repository.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Application.SystemSecurity
{
    public class LogApp
    {
        private ILogRepository service = new LogRepository();

        public List<SysLog> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<SysLog>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();
                expression = expression.And(t => t.FAccount.Contains(keyword));
            }
            if (!queryParam["timeType"].IsEmpty())
            {
                string timeType = queryParam["timeType"].ToString();
                DateTime startTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate();
                DateTime endTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate().AddDays(1);
                switch (timeType)
                {
                    case "1":
                        break;
                    case "2":
                        startTime = DateTime.Now.AddDays(-7);
                        break;
                    case "3":
                        startTime = DateTime.Now.AddMonths(-1);
                        break;
                    case "4":
                        startTime = DateTime.Now.AddMonths(-3);
                        break;
                    default:
                        break;
                }
                expression = expression.And(t => t.FDate >= startTime && t.FDate <= endTime);
            }
            return service.FindList(expression, pagination);
        }
        public void RemoveLog(string keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == "7")            //保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")       //保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")       //保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }
            var expression = ExtLinq.True<SysLog>();
            expression = expression.And(t => t.FDate <= operateTime);
            service.Delete(expression);
        }
        public void WriteDbLog(bool result, string resultLog)
        {
            SysLog logEntity = new SysLog();
            logEntity.FId = Common.GuId();
            logEntity.FDate = DateTime.Now;
            logEntity.FAccount = OperatorProvider.Provider.GetCurrent().UserCode;
            logEntity.FNickName = OperatorProvider.Provider.GetCurrent().UserName;
            logEntity.FIpaddress = Net.Ip; 
            logEntity.FIpaddressName = Net.GetLocation(logEntity.FIpaddress);
            logEntity.FResult = result;
            logEntity.FDescription = resultLog;
            logEntity.Create();
            service.Insert(logEntity);
        }
        public void WriteDbLog(SysLog logEntity)
        {
            logEntity.FId = Common.GuId();
            logEntity.FDate = DateTime.Now;
            logEntity.FIpaddress = Net.Ip;
            logEntity.FIpaddressName = Net.GetLocation(logEntity.FIpaddress);
            logEntity.Create();
            service.Insert(logEntity);
        }
    }
}
