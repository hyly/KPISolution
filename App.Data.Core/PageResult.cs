using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Core
{
    [DataContract]
    public class PageResult<T> where T : class
    {
        public PageResult(IEnumerable<T> data, Page page, int totalCount)
        {
            this.Page = page;
            this.Data = data;
            this.TotalCount = totalCount;
        }
        [DataMember(Name = "data")]
        public IEnumerable<T> Data { get; set; }

        [DataMember(Name = "page")]
        public Page Page { get; set; }

        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }
    }
}
