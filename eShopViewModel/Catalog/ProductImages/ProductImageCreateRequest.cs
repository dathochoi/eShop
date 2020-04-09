using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopViewModel.Catalog.ProductImages
{
    public class ProductImageCreateRequest
    {
        public string Caption { get; set; }
        public bool isDefault { get; set; }
        public int SortOrder { get; set; }
        public IFormFile ImageFilfe { get; set; }
    }
}
