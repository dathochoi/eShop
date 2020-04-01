using eShopData.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopData.Entities
{
    public class Promotion
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool ApplyForAll { get; set; }
        public int? DiscaountAmout { get; set; }
        public decimal? DsicaoutnAmout { get; set; }

        public string ProductId { get; set; }
        public string ProducCategoryIds { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
       
    }
}
