#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Domain._01_Infrastructure
* 项目描述 ：
* 类 名 称 ：IEntity
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Domain._01_Infrastructure
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/10/31 14:22:55
* 更新时间 ：2019/10/31 14:22:55
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using RabbitPlatform.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Data
{
   public class IEntity<T>
    {
        public void Create()
        {
            var entity = this as ICreationAudited;
            entity.FId = Common.GuId();
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.FCreatorUserId = LoginInfo.UserId;
            }
            entity.FCreatorTime = DateTime.Now;
        }
        public void Modify(string keyValue)
        {
            var entity = this as IModificationAudited;
            entity.FId = keyValue;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.FLastModifyUserId = LoginInfo.UserId;
            }
            entity.FLastModifyTime = DateTime.Now;
        }
        public void Remove()
        {
            var entity = this as IDeleteAudited;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.FDeleteUserId = LoginInfo.UserId;
            }
            entity.FDeleteTime = DateTime.Now;
            entity.FDeleteMark = true;
        }
    }
}
