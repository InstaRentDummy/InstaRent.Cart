using System;

namespace InstaRent.Cart.Services
{
    public class CartBagUpdatedEto
    {
        public Guid BagId { get; set; }
        public string BagName { get; set; } = string.Empty;
    }
}
