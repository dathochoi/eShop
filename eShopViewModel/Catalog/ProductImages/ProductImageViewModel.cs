using System;
using System.Collections.Generic;
using System.Text;

namespace eShopViewModel.Catalog.ProductImages
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public bool IsDefault { get; set; }
        public long FileSize { get; set; }

        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public DateTime DateCreate {get;set;}
        public int SortOrder { get; set; }
       
    }
}
