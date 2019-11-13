#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Repository.SystemSecurity
* 项目描述 ：
* 类 名 称 ：DbBackupRepository
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Repository.SystemSecurity
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/9 10:28:16
* 更新时间 ：2019/11/9 10:28:16
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
using RabbitPlatform.Data.IRepository.SystemSecurity;
using RabbitPlatform.Core;
using RabbitPlatform.Data.Extensions;

namespace RabbitPlatform.Repository.SystemSecurity
{
    public class DbBackupRepository : RepositoryBase<SysDbbackup>, IDbBackupRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                var dbBackupEntity = db.FindEntity<SysDbbackup>(keyValue);
                if (dbBackupEntity != null)
                {
                    FileHelper.DeleteFile(dbBackupEntity.FFilePath);
                }
                db.Delete<SysDbbackup>(dbBackupEntity);
                db.Commit();
            }
        }
        public void ExecuteDbBackup(SysDbbackup dbBackupEntity)
        {
            DbHelper.ExecuteSqlCommand(string.Format("backup database {0} to disk ='{1}'", dbBackupEntity.FDbName, dbBackupEntity.FFilePath));
            dbBackupEntity.FFileSize = FileHelper.ToFileSize(FileHelper.GetFileSize(dbBackupEntity.FFilePath));
            dbBackupEntity.FFilePath = "/Resource/DbBackup/" + dbBackupEntity.FFileName;
            this.Insert(dbBackupEntity);
        }
    }
}
