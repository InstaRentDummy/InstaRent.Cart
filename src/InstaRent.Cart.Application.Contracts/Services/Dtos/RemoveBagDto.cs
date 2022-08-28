using System;

namespace InstaRent.Cart.Services
{
    public class RemoveBagDto : IHasLesseeId
    {
        public Guid BagId { get; set; }

        public int? Count { get; set; }

        public string LesseeId { get; set; } = string.Empty;
    }
}
