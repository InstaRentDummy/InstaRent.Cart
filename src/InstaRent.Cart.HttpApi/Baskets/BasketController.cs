using InstaRent.Cart.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace InstaRent.Cart.Carts
{
    [RemoteService(Name = "cart")]
    [Area("cart")]
    [ControllerName("Basket")]
    [Route("api/cart/items")]
    public class BasketController : AbpController, ICartAppService
    {
        private readonly ICartAppService _cartAppService;

        public BasketController(ICartAppService cartAppService)
        {
            _cartAppService = cartAppService;
        }

        [HttpGet]
        [Route("{lesseeId}")]
        public virtual Task<CartDto> GetAsync(string lesseeId)
        {
            return _cartAppService.GetAsync(lesseeId);
        }

        [HttpPost]
        public virtual Task<CartDto> AddBagAsync(AddBagDto input)
        {
            return _cartAppService.AddBagAsync(input);
        }

        [HttpDelete]
        //[Route("{id}")]
        public virtual Task<CartDto> RemoveBagAsync(RemoveBagDto input)
        {
            return _cartAppService.RemoveBagAsync(input);
        }

        //[HttpDelete]
        //[Route("{id}")]
        //public virtual Task DeleteAsync(Guid id)
        //{
        //    return _bagsAppService.DeleteAsync(id);
        //}
    }
}
