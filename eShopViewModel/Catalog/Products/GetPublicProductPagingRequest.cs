using eShopViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopViewModel.Catalog.Products
{
    public class GetPublicProductPagingRequest: PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
