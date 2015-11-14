using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Core
{
    public interface ICacheServices
    {
        void Flush();

        int Count();

        bool Exists(string key);

        object Get(string key);

        /// <summary>
        /// If [DefaultExpiration] = True: add Cache Item which will be expired in [MinutesTilExpire] as default
        /// If [DefaultExpiration] = No: add Cache Item without expired Date. However, Cache Item may expire when system frees memory
        /// </summary>
        /// <param name="key">Cache key</param>
        /// <param name="value">Cache value</param>
        void Add(string key, object value);

        /// <summary>
        /// Add cache object with specific expiry date
        /// </summary>
        /// <param name="key">Cache key</param>
        /// <param name="value">Cache value</param>
        /// <param name="expiryDate">Expire Date</param>
        void Add(string key, object value, DateTime expiryDate);

        void Remove(string key);

        void RemoveAllWithKeyPrefix(string keyPrefix);

        void RemoveAllWithKeySuffix(string keySuffix);
    }
}
