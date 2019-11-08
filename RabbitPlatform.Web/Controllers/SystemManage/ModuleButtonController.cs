using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitPlatform.Application.SystemManage;
using RabbitPlatform.Web.App_Start.Handler;
using RabbitPlatform.Data;
using RabbitPlatform.Core;
namespace RabbitPlatform.Web.Controllers.SystemManage
{
    public class ModuleButtonController : MyControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult CloneButton()
        {
            return View();
        }
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson(string moduleId)
        {
            var data = moduleButtonApp.GetList(moduleId);
            var treeList = new List<TreeSelectModel>();
            foreach (SysModulebutton item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.FId;
                treeModel.text = item.FFullName;
                treeModel.parentId = item.FParentId;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string moduleId)
        {
            var data = moduleButtonApp.GetList(moduleId);
            var treeList = new List<TreeGridModel>();
            foreach (SysModulebutton item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.FParentId == item.FId) == 0 ? false : true;
                treeModel.id = item.FId;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.FParentId;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = moduleButtonApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SysModulebutton moduleButtonEntity, string keyValue)
        {
            moduleButtonApp.SubmitForm(moduleButtonEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            moduleButtonApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
        
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetCloneButtonTreeJson()
        {
            var moduledata = moduleApp.GetList();
            var buttondata = moduleButtonApp.GetList();
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
                tree.hasChildren = true;
                treeList.Add(tree);
            }
            foreach (SysModulebutton item in buttondata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = buttondata.Count(t => t.FParentId == item.FId) == 0 ? false : true;
                tree.id = item.FId;
                tree.text = item.FFullName;
                tree.value = item.FEnCode;
                if (item.FParentId == "0")
                {
                    tree.parentId = item.FModuleId;
                }
                else
                {
                    tree.parentId = item.FParentId;
                }
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.hasChildren = hasChildren;
                if (item.FIcon != "")
                {
                    tree.img = item.FIcon;
                }
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult SubmitCloneButton(string moduleId, string Ids)
        {
            moduleButtonApp.SubmitCloneButton(moduleId, Ids);
            return Success("克隆成功。");
        }
    }
}