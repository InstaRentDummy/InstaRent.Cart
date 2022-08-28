using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace InstaRent.Cart.Baskets
{
    public class Basket : AggregateRoot<string>
    {
        public List<BasketItem> Items { get; set; }

        private Basket()
        {
        }

        public Basket(string id)
            : base(id)
        {
            Items = new List<BasketItem>();
        }

        public void AddProduct(Guid bagId, string renterId, string bagName, double price, DateTime startDate, DateTime endDate, List<string> tags)
        {
            //    if (count < 1)
            //    {
            //        throw new ArgumentOutOfRangeException(nameof(count), "Bag count should be 1 or more!");
            //    }

            var count = 1;
            var item = Items.FirstOrDefault(x => x.BagId == bagId);
            if (item == null)
            {
                Items.Add(new BasketItem(bagId, renterId, bagName, price, startDate, endDate, tags));
            }
            else
            {
                item.Count += count;
            }
        }

        public void RemoveProduct(Guid bagId, int? count = null)
        {
            if (count is < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Product count should be null, 1 or more!");
            }
            var item = Items.FirstOrDefault(x => x.BagId == bagId);
            if (item == null)
            {
                return;
            }

            if (count == null || item.Count <= count)
            {
                Items.Remove(item);
                return;
            }

            item.Count -= count.Value;
        }

        public int GetProductCount(Guid bagId)
        {
            var item = Items.FirstOrDefault(x => x.BagId == bagId);
            return item?.Count ?? 0;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void Merge(Basket cart)
        {
            foreach (var item in cart.Items)
            {
                AddProduct(item.BagId, item.RenterId, item.BagName, item.Price, item.StartDate, item.EndDate, item.Tags);
            }
        }
    }
}
