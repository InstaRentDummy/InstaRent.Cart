using System;
using System.Collections.Generic;

namespace InstaRent.Cart.Services
{
    public class CartItemDto
    {
        public Guid BagId { get; set; }
        public string RenterId { get; set; } = string.Empty;
        public string BagName { get; set; } = string.Empty;
        public double price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
        public List<string> Tags { get; set; } = new List<string>();
    }
}
