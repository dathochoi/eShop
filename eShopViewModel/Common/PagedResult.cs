using System;
using System.Collections.Generic;
using System.Text;

namespace eShopViewModel.Common
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}
