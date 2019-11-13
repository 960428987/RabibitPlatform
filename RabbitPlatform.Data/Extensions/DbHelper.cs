#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Data.Extensions
* 项目描述 ：
* 类 名 称 ：DbHelper
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Data.Extensions
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/13 11:05:42
* 更新时间 ：2019/11/13 11:05:42
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using MySql.Data.MySqlClient;
using RabbitPlatform.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RabbitPlatform.Data.Extensions
{
    public class DbHelper
    {
        private static string connstring = ConfigHelper.Configuration["appseting:MysqlConnect"].ToString();
        public static int ExecuteSqlCommand(string cmdText)
        {
            using (DbConnection conn = new MySqlConnection(connstring))
            {
                DbCommand cmd = new MySqlCommand();
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
                return cmd.ExecuteNonQuery();
            }
        }
        private static void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction isOpenTrans, CommandType cmdType, string cmdText, DbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (isOpenTrans != null)
                cmd.Transaction = isOpenTrans;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                cmd.Parameters.AddRange(cmdParms);
            }
        }
    }
}
