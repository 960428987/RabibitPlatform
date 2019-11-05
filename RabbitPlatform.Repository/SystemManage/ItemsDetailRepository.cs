#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Repository.SystemManage
* 项目描述 ：
* 类 名 称 ：ItemsDetailRepository
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Repository.SystemManage
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/5 11:25:27
* 更新时间 ：2019/11/5 11:25:27
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using MySql.Data.MySqlClient;
using RabbitPlatform.Data;
using RabbitPlatform.Data.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace RabbitPlatform.Repository.SystemManage
{
    public class ItemsDetailRepository : RepositoryBase<SysItemsdetail>, IItemsDetailRepository
    {
        public List<SysItemsdetail> GetItemList(string enCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  d.*
                            FROM    Sys_ItemsDetail d
                                    INNER  JOIN Sys_Items i ON i.F_Id = d.F_ItemId
                            WHERE   1 = 1
                                    AND i.F_EnCode = @enCode
                                    AND d.F_EnabledMark = 1
                                    AND d.F_DeleteMark = 0
                            ORDER BY d.F_SortCode ASC");
            DbParameter[] parameter =
            {
                 new MySqlParameter("@enCode",enCode)
            };
            return this.FindList(strSql.ToString(), parameter);
        }
    }
}
