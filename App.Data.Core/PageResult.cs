using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Core
{
    public class PageResult<T> where T:class
    {
        public PageResult(IEnumerable<T> data,Page page, int totalCount)
        {
            this.Page = page;
            this.Data = data;
            this.TotalCount = totalCount;
        }
        public IEnumerable<T> Data { get; set; }
        public Page Page { get; set; }
        public int TotalCount { get; set; }

    }
}
