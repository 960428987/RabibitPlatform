#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Application.SystemSecurity
* 项目描述 ：
* 类 名 称 ：DbBackupApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Application.SystemSecurity
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/13 11:10:03
* 更新时间 ：2019/11/13 11:10:03
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using RabbitPlatform.Data;
using RabbitPlatform.Core;
using RabbitPlatform.Data.IRepository.SystemSecurity;
using RabbitPlatform.Repository.SystemSecurity;
using System.Linq;

namespace RabbitPlatform.Application.SystemSecurity
{
    public class DbBackupApp
    {
        private IDbBackupRepository service = new DbBackupRepository();

        public List<SysDbbackup> GetList(string queryJson)
        {
            var expression = ExtLinq.True<SysDbbackup>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "DbName":
                        expression = expression.And(t => t.FDbName.Contains(keyword));
                        break;
                    case "FileName":
                        expression = expression.And(t => t.FFileName.Contains(keyword));
                        break;
                }
            }
            return service.IQueryable(expression).OrderByDescending(t => t.FBackupTime).ToList();
        }
        public SysDbbackup GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }
        public void SubmitForm(SysDbbackup dbBackupEntity)
        {
            dbBackupEntity.FId = Common.GuId();
            dbBackupEntity.FEnabledMark = true;
            dbBackupEntity.FBackupTime = DateTime.Now;
            service.ExecuteDbBackup(dbBackupEntity);
        }
    }
}
