using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitPlatform.Application.SystemManage;
using RabbitPlatform.Web.App_Start.Handler;
using RabbitPlatform.Core;
using RabbitPlatform.Data;
namespace RabbitPlatform.Web.Controllers.SystemManage
{
    public class RoleAuthorizeController : MyControllerBase
    {
        private RoleAuthorizeApp roleAuthorizeApp = new RoleAuthorizeApp();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        public ActionResult GetPermissionTree(string roleId)
        {
            var moduledata = moduleApp.GetList();
            var buttondata = moduleButtonApp.GetList();
            var authorizedata = new List<SysRoleauthorize>();
            if (!string.IsNullOrEmpty(roleId))
            {
                authorizedata = roleAuthorizeApp.GetList(roleId);
            }
            var treeList = new List<TreeViewModel>();
            foreach (SysModule item in moduledata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = moduledata.Count(t => t.FParentId == item.FId) == 0 ? false : true;
                tree.id = item.FId;
                tree.text = item.FFullName;
                tree.value = item.FEnCode;
                tree.parentId = item.FParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = authorizedata.Count(t => t.FItemId == item.FId);
                tree.hasChildren = true;
                tree.img = item.FIcon == "" ? "" : item.FIcon;
                treeList.Add(tree);
            }
            foreach (SysModulebutton item in buttondata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = buttondata.Count(t => t.FParentId == item.FId) == 0 ? false : true;
                tree.id = item.FId;
                tree.text = item.FFullName;
                tree.value = item.FEnCode;
                tree.parentId = item.FParentId == "0" ? item.FModuleId : item.FParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = authorizedata.Count(t => t.FItemId == item.FId);
                tree.hasChildren = hasChildren;
                tree.img = item.FIcon == "" ? "" : item.FIcon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
    }
}