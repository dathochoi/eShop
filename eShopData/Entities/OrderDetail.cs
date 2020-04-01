using System;
using System.Collections.Generic;
using System.Text;

namespace eShopData.Entities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quanity { get; set; }
        public decimal Price { get; set; }
        public Order Order {get;set;}
        public Product Product { get; set; }
    }
}
