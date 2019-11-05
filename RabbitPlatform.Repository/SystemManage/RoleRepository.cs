#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Repository.SystemManage
* 项目描述 ：
* 类 名 称 ：RoleRepository
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Repository.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/5 11:56:51
* 更新时间 ：2019/11/5 11:56:51
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using RabbitPlatform.Data;
using RabbitPlatform.Data.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Repository.SystemManage
{
    public class RoleRepository : RepositoryBase<SysRole>, IRoleRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<SysRole>(t => t.FId == keyValue);
                db.Delete<SysRoleauthorize>(t => t.FObjectId == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(SysRole roleEntity, List<SysRoleauthorize> roleAuthorizeEntitys, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(roleEntity);
                }
                else
                {
                    roleEntity.FCategory = 1;
                    db.Insert(roleEntity);
                }
                db.Delete<SysRoleauthorize>(t => t.FObjectId == roleEntity.FId);
                db.Insert(roleAuthorizeEntitys);
                db.Commit();
            }
        }
    }
}
