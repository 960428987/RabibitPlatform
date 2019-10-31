#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Data.Repository
* 项目描述 ：
* 类 名 称 ：IRepositoryBase
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Data.Repository
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/10/31 15:38:16
* 更新时间 ：2019/10/31 15:38:16
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using RabbitPlatform.Core;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RabbitPlatform.Data
{
    public interface IRepositoryBase : IDisposable
    {
        IRepositoryBase BeginTrans();
        int Commit();
        int Insert<TEntity>(TEntity entity) where TEntity : class;
        int Insert<TEntity>(List<TEntity> entitys) where TEntity : class;
        int Update<TEntity>(TEntity entity) where TEntity : class;
        int Delete<TEntity>(TEntity entity) where TEntity : class;
        int Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity FindEntity<TEntity>(object keyValue) where TEntity : class;
        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        IQueryable<TEntity> IQueryable<TEntity>() where TEntity : class;
        IQueryable<TEntity> IQueryable<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        List<TEntity> FindList<TEntity>(string strSql) where TEntity : class;
        List<TEntity> FindList<TEntity>(string strSql, DbParameter[] dbParameter) where TEntity : class;
        List<TEntity> FindList<TEntity>(Pagination pagination) where TEntity : class, new();
        List<TEntity> FindList<TEntity>(Expression<Func<TEntity, bool>> predicate, Pagination pagination) where TEntity : class, new();
    }
}
