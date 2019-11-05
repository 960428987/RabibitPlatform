#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Application.SystemManage
* 项目描述 ：
* 类 名 称 ：ModuleButtonApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Application.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/5 12:06:29
* 更新时间 ：2019/11/5 12:06:29
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using RabbitPlatform.Core;
using RabbitPlatform.Data;
using RabbitPlatform.Data.IRepository.SystemManage;
using RabbitPlatform.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabbitPlatform.Application.SystemManage
{
    public class ModuleButtonApp
    {
        private IModuleButtonRepository service = new ModuleButtonRepository();

        public List<SysModulebutton> GetList(string moduleId = "")
        {
            var expression = ExtLinq.True<SysModulebutton>();
            if (!string.IsNullOrEmpty(moduleId))
            {
                expression = expression.And(t => t.FModuleId == moduleId);
            }
            return service.IQueryable(expression).OrderBy(t => t.FSortCode).ToList();
        }
        public SysModulebutton GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Count(t => t.FParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.Delete(t => t.FId == keyValue);
            }
        }
        public void SubmitForm(SysModulebutton moduleButtonEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleButtonEntity.Modify(keyValue);
                service.Update(moduleButtonEntity);
            }
            else
            {
                moduleButtonEntity.Create();
                service.Insert(moduleButtonEntity);
            }
        }
        public void SubmitCloneButton(string moduleId, string Ids)
        {
            string[] ArrayId = Ids.Split(',');
            var data = this.GetList();
            List<SysModulebutton> entitys = new List<SysModulebutton>();
            foreach (string item in ArrayId)
            {
                SysModulebutton moduleButtonEntity = data.Find(t => t.FId == item);
                moduleButtonEntity.FId = Common.GuId();
                moduleButtonEntity.FModuleId = moduleId;
                entitys.Add(moduleButtonEntity);
            }
            service.SubmitCloneButton(entitys);
        }
    }
}
