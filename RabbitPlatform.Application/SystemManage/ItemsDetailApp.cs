#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Application.SystemManage
* 项目描述 ：
* 类 名 称 ：ItemsDetailApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Application.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/5 11:16:46
* 更新时间 ：2019/11/5 11:16:46
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using RabbitPlatform.Data.IRepository.SystemManage;
using RabbitPlatform.Repository.SystemManage;
using RabbitPlatform.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RabbitPlatform.Core;
using System.Linq;

namespace RabbitPlatform.Application.SystemManage
{
    public class ItemsDetailApp
    {
        private IItemsDetailRepository service = new ItemsDetailRepository();

        public List<SysItemsdetail> GetList(string itemId = "", string keyword = "")
        {
            var expression = ExtLinq.True<SysItemsdetail>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.FItemId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FItemName.Contains(keyword));
                expression = expression.Or(t => t.FItemCode.Contains(keyword));
            }
            return service.IQueryable(expression).OrderBy(t => t.FSortCode).ToList();
        }
        public List<SysItemsdetail> GetItemList(string enCode)
        {
            return service.GetItemList(enCode);
        }
        public SysItemsdetail GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.FId == keyValue);
        }
        public void SubmitForm(SysItemsdetail itemsDetailEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                itemsDetailEntity.Modify(keyValue);
                service.Update(itemsDetailEntity);
            }
            else
            {
                itemsDetailEntity.Create();
                service.Insert(itemsDetailEntity);
            }
        }
    }
}
