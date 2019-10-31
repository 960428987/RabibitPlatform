#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Core.Web
* 项目描述 ：
* 类 名 称 ：Pagination
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Core.Web
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/10/31 15:37:35
* 更新时间 ：2019/10/31 15:37:35
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Core
{
    /// <summary>
    /// 分页信息
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// 每页行数
        /// </summary>
        public int rows { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 排序列
        /// </summary>
        public string sidx { get; set; }
        /// <summary>
        /// 排序类型
        /// </summary>
        public string sord { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int records { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int total
        {
            get
            {
                if (records > 0)
                {
                    return records % this.rows == 0 ? records / this.rows : records / this.rows + 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
