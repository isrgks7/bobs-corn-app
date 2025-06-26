using System;

namespace BobCorn.Domain.Entities
{
    public class CornPurchase
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; }
        public DateTime PurchaseTime { get; set; }
    }
}
