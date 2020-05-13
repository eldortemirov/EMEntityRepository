using System;
using System.Collections.Generic;
using System.Text;

namespace EMEntityRepository.ResultModels
{
    public class PagedResult<T> where T:class
    {
        public IList<T> Data { get; set; }

        public int Total { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
