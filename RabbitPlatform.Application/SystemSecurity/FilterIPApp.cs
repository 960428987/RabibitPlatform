#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Application.SystemSecurity
* 项目描述 ：
* 类 名 称 ：FilterIPApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Application.SystemSecurity
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/13 11:09:52
* 更新时间 ：2019/11/13 11:09:52
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using RabbitPlatform.Data.IRepository.SystemSecurity;
using RabbitPlatform.Repository.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Text;
using RabbitPlatform.Data;
using RabbitPlatform.Core;
using System.Linq;

namespace RabbitPlatform.Application.SystemSecurity
{
    public class FilterIPApp
    {
        private IFilterIPRepository service = new FilterIPRepository();

        public List<SysFilterip> GetList(string keyword)
        {
            var expression = ExtLinq.True<SysFilterip>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FStartIp.Contains(keyword));
            }
            return service.IQueryable(expression).OrderByDescending(t => t.FDeleteTime).ToList();
        }
        public SysFilterip GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.FId == keyValue);
        }
        public void SubmitForm(SysFilterip filterIPEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                filterIPEntity.Modify(keyValue);
                service.Update(filterIPEntity);
            }
            else
            {
                filterIPEntity.Create();
                service.Insert(filterIPEntity);
            }
        }
    }
}
