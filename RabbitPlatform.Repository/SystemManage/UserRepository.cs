#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Repository.SystemManage
* 项目描述 ：
* 类 名 称 ：UserRepository
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Repository.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/1 15:46:16
* 更新时间 ：2019/11/1 15:46:16
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using RabbitPlatform.Core;
using RabbitPlatform.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Repository.SystemManage
{
    public class UserRepository : RepositoryBase<SysUser>, IUserRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<SysUser>(t => t.FId == keyValue);
                db.Delete<SysUserlogon>(t => t.FUserId == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(SysUser userEntity, SysUserlogon userLogOnEntity, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(userEntity);
                }
                else
                {
                    userLogOnEntity.FId = userEntity.FId;
                    userLogOnEntity.FUserId = userEntity.FId;
                    userLogOnEntity.FUserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
                    userLogOnEntity.FUserPassword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userLogOnEntity.FUserPassword, 32).ToLower(), userLogOnEntity.FUserSecretkey).ToLower(), 32).ToLower();
                    db.Insert(userEntity);
                    db.Insert(userLogOnEntity);
                }
                db.Commit();
            }
        }
    }
}
