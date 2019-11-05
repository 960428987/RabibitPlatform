#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Application.SystemManage
* 项目描述 ：
* 类 名 称 ：RoleAuthorizeApp
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Application.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/5 11:18:40
* 更新时间 ：2019/11/5 11:18:40
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
using System.Linq;
using RabbitPlatform.Core;
using RabbitPlatform.Data.ViewModel;
using RabbitPlatform.Core.Cache;

namespace RabbitPlatform.Application.SystemManage
{
    public class RoleAuthorizeApp
    {
        private IRoleAuthorizeRepository service = new RoleAuthorizeRepository();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        public List<SysRoleauthorize> GetList(string ObjectId)
        {
            return service.IQueryable(t => t.FObjectId == ObjectId).ToList();
        }
        public List<SysModule> GetMenuList(string roleId)
        {
            var data = new List<SysModule>();
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                data = moduleApp.GetList();
            }
            else
            {
                var moduledata = moduleApp.GetList();
                var authorizedata = service.IQueryable(t => t.FObjectId == roleId && t.FItemType == 1).ToList();
                foreach (var item in authorizedata)
                {
                    SysModule moduleEntity = moduledata.Find(t => t.FId == item.FItemId);
                    if (moduleEntity != null)
                    {
                        data.Add(moduleEntity);
                    }
                }
            }
            return data.OrderBy(t => t.FSortCode).ToList();
        }
        public List<SysModulebutton> GetButtonList(string roleId)
        {
            var data = new List<SysModulebutton>();
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                data = moduleButtonApp.GetList();
            }
            else
            {
                var buttondata = moduleButtonApp.GetList();
                var authorizedata = service.IQueryable(t => t.FObjectId == roleId && t.FItemType == 2).ToList();
                foreach (var item in authorizedata)
                {
                    SysModulebutton moduleButtonEntity = buttondata.Find(t => t.FId == item.FItemId);
                    if (moduleButtonEntity != null)
                    {
                        data.Add(moduleButtonEntity);
                    }
                }
            }
            return data.OrderBy(t => t.FSortCode).ToList();
        }
        public bool ActionValidate(string roleId, string moduleId, string action)
        {
            var authorizeurldata = new List<AuthorizeActionModel>();
            var cachedata = CacheFactory.Cache().GetCache<List<AuthorizeActionModel>>("authorizeurldata_" + roleId);
            if (cachedata == null)
            {
                var moduledata = moduleApp.GetList();
                var buttondata = moduleButtonApp.GetList();
                var authorizedata = service.IQueryable(t => t.FObjectId == roleId).ToList();
                foreach (var item in authorizedata)
                {
                    if (item.FItemType == 1)
                    {
                        SysModule moduleEntity = moduledata.Find(t => t.FId == item.FItemId);
                        authorizeurldata.Add(new AuthorizeActionModel { F_Id = moduleEntity.FId, F_UrlAddress = moduleEntity.FUrlAddress });
                    }
                    else if (item.FItemType == 2)
                    {
                        SysModulebutton moduleButtonEntity = buttondata.Find(t => t.FId == item.FItemId);
                        authorizeurldata.Add(new AuthorizeActionModel { F_Id = moduleButtonEntity.FModuleId, F_UrlAddress = moduleButtonEntity.FUrlAddress });
                    }
                }
                CacheFactory.Cache().WriteCache(authorizeurldata, "authorizeurldata_" + roleId, 5);
            }
            else
            {
                authorizeurldata = cachedata;
            }
            authorizeurldata = authorizeurldata.FindAll(t => t.F_Id.Equals(moduleId));
            foreach (var item in authorizeurldata)
            {
                if (!string.IsNullOrEmpty(item.F_UrlAddress))
                {
                    string[] url = item.F_UrlAddress.Split('?');
                    if (item.F_Id == moduleId && url[0] == action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
