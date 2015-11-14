using App.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Implementation.Cache
{
    public class BuiltInCache : ICacheServices
    {
        private static object _synchRoot = new object();
        private static Dictionary<string, BuiltInCacheItem> _cache = new Dictionary<string, BuiltInCacheItem>();

        private readonly int _minutesTilExpire;
        private readonly bool _defaultExpiration;

        public BuiltInCache(int minutesTilExpire, bool defaultExpiration)
        {
            _minutesTilExpire = minutesTilExpire;
            _defaultExpiration = defaultExpiration;
        }

        static BuiltInCache()
        {
            _cache = new Dictionary<string, BuiltInCacheItem>();
        }

        public void Flush()
        {
            lock (_synchRoot)
            {
                _cache = new Dictionary<string, BuiltInCacheItem>();
            }
        }

        public int Count()
        {
            lock (_synchRoot)
            {
                return _cache.Count();
            }
        }

        public bool Exists(string key)
        {
            lock (_synchRoot)
            {
                return _cache.ContainsKey(key) ? !_cache[key].HasExpired : false;
            }
        }

        public object Get(string key)
        {
            lock (_synchRoot)
            {
                BuiltInCacheItem obj;
                if (_cache.TryGetValue(key, out obj) && !obj.HasExpired) return obj.Item;
                return null;
            }
        }

        public void Add(string key, object value)
        {
            DateTime expiryDate = _defaultExpiration ? DateTime.Now.AddMinutes(_minutesTilExpire) : DateTime.MaxValue;
            Add(key, value, expiryDate);
        }

        public void Add(string key, object value, DateTime expiryDate)
        {
            lock (_synchRoot)
            {
                BuiltInCacheItem obj = new BuiltInCacheItem(value, expiryDate);
                _cache[key] = obj;
            }
        }

        public void Remove(string key)
        {
            lock (_synchRoot)
            {
                _cache.Remove(key);
            }
        }

        public void RemoveAllWithKeyPrefix(string keyPrefix)
        {
            List<string> keysToRemove = new List<string>();
            var enumerator = _cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                string key = enumerator.Current.Key.ToString();

                if (key.StartsWith(keyPrefix, StringComparison.InvariantCultureIgnoreCase))
                {
                    keysToRemove.Add(key);
                }
            }

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        public void RemoveAllWithKeySuffix(string keySuffix)
        {
            List<string> keysToRemove = new List<string>();
            var enumerator = _cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                string key = enumerator.Current.Key.ToString();

                if (key.EndsWith(keySuffix, StringComparison.InvariantCultureIgnoreCase))
                {
                    keysToRemove.Add(key);
                }
            }

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }
    }
    class BuiltInCacheItem
    {
        public BuiltInCacheItem(object item, DateTime experationDate)
        {
            Item = item;
            ExperationDate = experationDate;
        }

        public object Item { get; set; }

        public DateTime ExperationDate { get; set; }

        public bool HasExpired
        {
            get
            {
                return ExperationDate < DateTime.Now;
            }
        }
    }
}
