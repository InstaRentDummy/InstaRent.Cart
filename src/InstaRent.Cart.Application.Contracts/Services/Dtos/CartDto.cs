using System.Collections.Generic;

namespace InstaRent.Cart.Services
{
    public class CartDto
    {
        public double TotalPrice { get; set; }
        public List<CartItemDto> Items { get; set; }

        public CartDto()
        {
            Items = new List<CartItemDto>();
        }
    }
}
