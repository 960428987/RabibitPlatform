#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Application.SystemManage
* 项目描述 ：
* 类 名 称 ：DutyApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Application.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/5 11:18:23
* 更新时间 ：2019/11/5 11:18:23
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using RabbitPlatform.Data.IRepository.SystemManage;
using RabbitPlatform.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Text;
using RabbitPlatform.Data;
using RabbitPlatform.Core;
using System.Linq;

namespace RabbitPlatform.Application.SystemManage
{
    public class DutyApp
    {
        private IRoleRepository service = new RoleRepository();

        public List<SysRole> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<SysRole>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FFullName.Contains(keyword));
                expression = expression.Or(t => t.FEnCode.Contains(keyword));
            }
            expression = expression.And(t => t.FCategory == 2);
            return service.IQueryable(expression).OrderBy(t => t.FSortCode).ToList();
        }
        public SysRole GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.FId == keyValue);
        }
        public void SubmitForm(SysRole roleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.Modify(keyValue);
                service.Update(roleEntity);
            }
            else
            {
                roleEntity.Create();
                roleEntity.FCategory = 2;
                service.Insert(roleEntity);
            }
        }
    }
}
