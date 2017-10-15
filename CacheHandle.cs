using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace PersistentWebService
{
    public class CacheHandle
    {
        private const string DummyCacheItemKey = "__DummyCacheItemKey_";
        public static void RegisterCacheEntry(string url)
        {
            RegisterCacheEntry(url, 5);
            RegisterCacheEntry(url, 7);
            RegisterCacheEntry(url, 11);
        }

        private static void RegisterCacheEntry(string url, int minutes)
        {
            if (HttpContext.Current.Cache[DummyCacheItemKey + minutes] == null)
            {
                HttpContext.Current.Cache.Add(DummyCacheItemKey + minutes, url, null, Cache.NoAbsoluteExpiration,
                    TimeSpan.FromMinutes(minutes), CacheItemPriority.NotRemovable, CacheItemRemovedCallback);
            }
        }

        // 缓存项过期时程序模拟点击页面，阻止应用程序结束
        private static void CacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            try
            {
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    client.DownloadData(value.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
            
        }
    }
}
