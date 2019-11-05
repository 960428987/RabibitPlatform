#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：RabbitPlatform.Core.Cache
* 项目描述 ：
* 类 名 称 ：Cache
* 类 描 述 ：
* 所在的域 ：DESKTOP-O4LCU7F
* 命名空间 ：RabbitPlatform.Core.Cache
* 机器名称 ：DESKTOP-O4LCU7F 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：welus
* 创建时间 ：2019/11/5 12:37:55
* 更新时间 ：2019/11/5 12:37:55
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ welus 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace RabbitPlatform.Core.Cache
{
    public class Cache : ICache
    {
        //private static System.Web.Caching.Cache cache = HttpRuntime.Cache;
        private static IMemoryCache cache = new MemoryCache(Options.Create(new MemoryCacheOptions()));
      public T GetCache<T>(string cacheKey) where T : class
        {
            if (cache.Get(cacheKey) != null)
            {
                return (T)cache.Get(cacheKey);
            }
            //if (cache[cacheKey] != null)
            //{
            //    return (T)cache[cacheKey];
            //}
            return default(T);
        }
        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            //cache.Set(cacheKey, value,new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
            cache.Set(cacheKey, value, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10)));
            // cache.Insert(cacheKey, value, null, DateTime.Now.AddMinutes(10), System.Web.Caching.Cache.NoSlidingExpiration);
        }
        public void WriteCache<T>(T value, string cacheKey, int expireTime) where T : class
        {
            cache.Set(cacheKey, value, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(expireTime)));
            //cache.Insert(cacheKey, value, null, expireTime, System.Web.Caching.Cache.NoSlidingExpiration);
        }
        public void RemoveCache(string cacheKey)
        {
            cache.Remove(cacheKey);
        }
        public void RemoveCache()
        {
            //IDictionaryEnumerator CacheEnum = cache.GetEnumerator();
            //while (CacheEnum.MoveNext())
            //{
            //    cache.Remove(CacheEnum.Key.ToString());
            //}
        }

        
    }
}
