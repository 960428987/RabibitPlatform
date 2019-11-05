#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Core.Extend
* 项目描述 ：
* 类 名 称 ：ExtTable
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Core.Extend
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/5 13:57:23
* 更新时间 ：2019/11/5 13:57:23
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RabbitPlatform.Core
{
    public static class ExtTable
    {
        /// <summary>
        /// 获取表里某页的数据
        /// </summary>
        /// <param name="data">表数据</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="allPage">返回总页数</param>
        /// <returns>返回当页表数据</returns>
        public static DataTable GetPage(this DataTable data, int pageIndex, int pageSize, out int allPage)
        {
            allPage = data.Rows.Count / pageSize;
            allPage += data.Rows.Count % pageSize == 0 ? 0 : 1;
            DataTable Ntable = data.Clone();
            int startIndex = pageIndex * pageSize;
            int endIndex = startIndex + pageSize > data.Rows.Count ? data.Rows.Count : startIndex + pageSize;
            if (startIndex < endIndex)
                for (int i = startIndex; i < endIndex; i++)
                {
                    Ntable.ImportRow(data.Rows[i]);
                }
            return Ntable;
        }
        /// <summary>
        /// 根据字段过滤表的内容
        /// </summary>
        /// <param name="data">表数据</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        /// 
        public static DataTable GetDataFilter(DataTable data, string condition)
        {
            if (data != null && data.Rows.Count > 0)
            {
                if (condition.Trim() == "")
                {
                    return data;
                }
                else
                {
                    DataTable newdt = new DataTable();
                    newdt = data.Clone();
                    DataRow[] dr = data.Select(condition);
                    for (int i = 0; i < dr.Length; i++)
                    {
                        newdt.ImportRow((DataRow)dr[i]);
                    }
                    return newdt;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
