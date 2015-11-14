using App.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Services.Implementation.Cache
{
    class HttpContextCache : ICacheServices
    {
        private readonly HttpContext httpContext = null;
        public HttpContextCache(HttpContext context)
        {
            this.httpContext = context;
        }
        public void Flush()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return this.httpContext.Items.Count;
        }

        public bool Exists(string key)
        {
            return this.httpContext.Items.Contains(key);
        }

        public object Get(string key)
        {
            return this.httpContext.Items[key];
        }

        public void Add(string key, object value)
        {
            this.httpContext.Items.Add(key, value);
        }

        public void Add(string key, object value, DateTime expiryDate)
        {
            this.httpContext.Items.Add(key, value);
        }

        public void Remove(string key)
        {
            this.httpContext.Items.Remove(key);
        }

        public void RemoveAllWithKeyPrefix(string keyPrefix)
        {
            this.httpContext.Items.Remove(keyPrefix);
        }

        public void RemoveAllWithKeySuffix(string keySuffix)
        {
            throw new NotImplementedException();
        }
    }
}
