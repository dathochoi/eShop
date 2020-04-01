using eShopData.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopData.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ExternalTransactionId { get; set; }
        public decimal Amout { get; set; }
        public decimal Fee { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
        public TransactionStatus Status { get; set; }
        public string Provide { get; set; }
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
