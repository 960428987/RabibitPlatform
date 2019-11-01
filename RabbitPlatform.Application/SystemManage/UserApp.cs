#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Application.SystemManage
* 项目描述 ：
* 类 名 称 ：UserApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Application.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/10/31 15:31:15
* 更新时间 ：2019/10/31 15:31:15
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using RabbitPlatform.Core;
using RabbitPlatform.Data;
using RabbitPlatform.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Application.SystemManage
{
    public class UserApp
    {
        private IUserRepository service = new UserRepository();
        private UserLogOnApp userLogOnApp = new UserLogOnApp();

        public List<SysUser> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<SysUser>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FAccount.Contains(keyword));
                expression = expression.Or(t => t.FRealName.Contains(keyword));
                expression = expression.Or(t => t.FMobilePhone.Contains(keyword));
            }
            expression = expression.And(t => t.FAccount != "admin");
            return service.FindList(expression, pagination);
        }
        public SysUser GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }
        public void SubmitForm(SysUser userEntity, SysUserlogon userLogOnEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                userEntity.Modify(keyValue);
            }
            else
            {
                userEntity.Create();
            }
            service.SubmitForm(userEntity, userLogOnEntity, keyValue);
        }
        public void UpdateForm(SysUser userEntity)
        {
            service.Update(userEntity);
        }
        public SysUser CheckLogin(string username, string password)
        {
            SysUser userEntity = service.FindEntity(t => t.FAccount == username);
            if (userEntity != null)
            {
                if (userEntity.FEnabledMark == true)
                {
                    SysUserlogon userLogOnEntity = userLogOnApp.GetForm(userEntity.FId);
                    string dbPassword = Md5.md5(DESEncrypt.Encrypt(password.ToLower(), userLogOnEntity.FUserSecretkey).ToLower(), 32).ToLower();
                    if (dbPassword == userLogOnEntity.FUserPassword)
                    {
                        DateTime lastVisitTime = DateTime.Now;
                        int LogOnCount = (userLogOnEntity.FLogOnCount).ToInt() + 1;
                        if (userLogOnEntity.FLastVisitTime != null)
                        {
                            userLogOnEntity.FPreviousVisitTime = userLogOnEntity.FLastVisitTime.ToDate();
                        }
                        userLogOnEntity.FLastVisitTime = lastVisitTime;
                        userLogOnEntity.FLogOnCount = LogOnCount;
                        userLogOnApp.UpdateForm(userLogOnEntity);
                        return userEntity;
                    }
                    else
                    {
                        throw new Exception("密码不正确，请重新输入");
                    }
                }
                else
                {
                    throw new Exception("账户被系统锁定,请联系管理员");
                }
            }
            else
            {
                throw new Exception("账户不存在，请重新输入");
            }
        }
    }
}
