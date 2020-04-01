using System;
using System.Collections.Generic;
using System.Text;

namespace eShopData.Entities
{
    public  class Language
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
        public List<CategoryTranslatation> CategoryTranslatations { get; set; }
    }
}
