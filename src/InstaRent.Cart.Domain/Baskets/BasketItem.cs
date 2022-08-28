using System;
using System.Collections.Generic;

namespace InstaRent.Cart.Baskets
{
    public class BasketItem
    {
        public Guid BagId { get; private set; }
        public int Count { get; internal set; }
        public string RenterId { get; set; } = string.Empty;
        public string BagName { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Tags { get; set; } = new List<string>();

        private BasketItem()
        {

        }

        public BasketItem(Guid bagId, string renterId, string bagName, double price, DateTime startDate, DateTime endDate, List<string> tags, int count = 1)
        //public BasketItem(Guid bagId, int count = 1)
        {
            BagId = bagId;
            Count = count;
            RenterId = renterId;
            BagName = bagName;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            Tags = tags;
        }
    }
}
