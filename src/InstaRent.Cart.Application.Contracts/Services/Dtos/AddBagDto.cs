using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstaRent.Cart.Services
{
    public class AddBagDto : IHasLesseeId
    {
        public Guid BagId { get; set; }
        public string BagName { get; set; }
        public string RenterId { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<string> Tags { get; set; }

        [Range(1, int.MaxValue)]
        public int Count { get; set; } = 1;

        public string LesseeId { get; set; } = string.Empty;
    }
}
