using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitPlatform.Core;
using RabbitPlatform.Data;
using RabbitPlatform.Application.SystemManage;
namespace RabbitPlatform.Web.Controllers
{
    public class ClientsDataController : Controller
    {
        [HttpGet]
        [HandlerAjaxOnly]
        public IActionResult GetClientsDataJson()
        {
            var data = new
            {
                dataItems = this.GetDataItemList(),
                organize = this.GetOrganizeList(),
                role = this.GetRoleList(),
                duty = this.GetDutyList(),
                user = "",
                authorizeMenu = this.GetMenuList(),
                authorizeButton = this.GetMenuButtonList(),
            };
            return Content(data.ToJson());
        }
        private object GetDataItemList()
        {
            var itemdata = new ItemsDetailApp().GetList();
            Dictionary<string, object> dictionaryItem = new Dictionary<string, object>();
            foreach (var item in new ItemsApp().GetList())
            {
                var dataItemList = itemdata.FindAll(t => t.FItemId.Equals(item.FId));
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
                foreach (var itemList in dataItemList)
                {
                    dictionaryItemList.Add(itemList.FItemCode, itemList.FItemName);
                }
                dictionaryItem.Add(item.FEnCode, dictionaryItemList);
            }
            return dictionaryItem;
        }
        private object GetOrganizeList()
        {
            OrganizeApp organizeApp = new OrganizeApp();
            var data = organizeApp.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (SysOrganize item in data)
            {
                var fieldItem = new
                {
                    encode = item.FEnCode,
                    fullname = item.FFullName
                };
                dictionary.Add(item.FId, fieldItem);
            }
            return dictionary;
        }
        private object GetRoleList()
        {
            RoleApp roleApp = new RoleApp();
            var data = roleApp.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (SysRole item in data)
            {
                var fieldItem = new
                {
                    encode = item.FEnCode,
                    fullname = item.FFullName
                };
                dictionary.Add(item.FId, fieldItem);
            }
            return dictionary;
        }
        private object GetDutyList()
        {
            DutyApp dutyApp = new DutyApp();
            var data = dutyApp.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (SysRole item in data)
            {
                var fieldItem = new
                {
                    encode = item.FEnCode,
                    fullname = item.FFullName
                };
                dictionary.Add(item.FId, fieldItem);
            }
            return dictionary;
        }
        private object GetMenuList()
        {
            var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            return ToMenuJson(new RoleAuthorizeApp().GetMenuList(roleId), "0");
        }
        private string ToMenuJson(List<SysModule> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<SysModule> entitys = data.FindAll(t => t.FParentId == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.FId) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }
        private object GetMenuButtonList()
        {
            var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            var data = new RoleAuthorizeApp().GetButtonList(roleId);
            var dataModuleId = data.Distinct(new ExtList<SysModulebutton>("FModuleId"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (SysModulebutton item in dataModuleId)
            {
                if (item.FModuleId == "e72c75d0-3a69-41ad-b220-13c9a62ec788")
                {

                }
                var buttonList = data.Where(t => t.FModuleId.Equals(item.FModuleId));
                dictionary.Add(item.FModuleId, buttonList);
            }
            return dictionary;
        }
    }
}