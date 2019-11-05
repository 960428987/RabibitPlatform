#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Application.SystemManage
* 项目描述 ：
* 类 名 称 ：RoleApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Application.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/5 11:17:49
* 更新时间 ：2019/11/5 11:17:49
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using RabbitPlatform.Data.IRepository.SystemManage;
using RabbitPlatform.Repository.SystemManage;
using System;
using RabbitPlatform.Data;
using System.Collections.Generic;
using System.Text;
using RabbitPlatform.Core;
using System.Linq;

namespace RabbitPlatform.Application.SystemManage
{
    public class RoleApp
    {
        private IRoleRepository service = new RoleRepository();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        public List<SysRole> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<SysRole>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FFullName.Contains(keyword));
                expression = expression.Or(t => t.FEnCode.Contains(keyword));
            }
            expression = expression.And(t => t.FCategory == 1);
            return service.IQueryable(expression).OrderBy(t => t.FSortCode).ToList();
        }
        public SysRole GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }
        public void SubmitForm(SysRole roleEntity, string[] permissionIds, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.FId = keyValue;
            }
            else
            {
                roleEntity.FId = Common.GuId();
            }
            var moduledata = moduleApp.GetList();
            var buttondata = moduleButtonApp.GetList();
            List<SysRoleauthorize> roleAuthorizeEntitys = new List<SysRoleauthorize>();
            foreach (var itemId in permissionIds)
            {
                SysRoleauthorize roleAuthorizeEntity = new SysRoleauthorize();
                roleAuthorizeEntity.FId = Common.GuId();
                roleAuthorizeEntity.FObjectType = 1;
                roleAuthorizeEntity.FObjectId = roleEntity.FId;
                roleAuthorizeEntity.FItemId = itemId;
                if (moduledata.Find(t => t.FId == itemId) != null)
                {
                    roleAuthorizeEntity.FItemType = 1;
                }
                if (buttondata.Find(t => t.FId == itemId) != null)
                {
                    roleAuthorizeEntity.FItemType = 2;
                }
                roleAuthorizeEntitys.Add(roleAuthorizeEntity);
            }
            service.SubmitForm(roleEntity, roleAuthorizeEntitys, keyValue);
        }
    }
}
