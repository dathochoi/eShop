using System;
using System.Collections.Generic;
using System.Text;

namespace eShopData.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid UserID { get; set; }
        public Product Product { get; set; }

        public DateTime DateCreate { get; set; }
        public AppUser AppUser { get; set; }

    }
}
