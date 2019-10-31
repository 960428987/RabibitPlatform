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
* 创建时间 ：2019/10/31 15:39:28
* 更新时间 ：2019/10/31 15:39:28
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitPlatform.Data
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : class, new()
    {
        int Insert(TEntity entity);
        int Insert(List<TEntity> entitys);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        TEntity FindEntity(object keyValue);
        TEntity FindEntity(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> IQueryable();
        IQueryable<TEntity> IQueryable(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FindList(string strSql);
        List<TEntity> FindList(string strSql, DbParameter[] dbParameter);
        List<TEntity> FindList(Pagination pagination);
        List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Pagination pagination);
    }
}
