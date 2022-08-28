using InstaRent.Cart.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace InstaRent.Cart.Services
{
    public class CartAppService : ApplicationService, ICartAppService
    {
        private readonly ICartRepository _basketRepository;
        //private readonly ICartBagService _basketProductService;

        public CartAppService(
            ICartRepository basketRepository)
        {
            _basketRepository = basketRepository;
            //_basketProductService = basketProductService;
            //LocalizationResource = typeof(BasketServiceResource);
        }

        public async Task<CartDto> GetAsync(string lesseeId)
        {
            //Guid userId = new Guid(lesseeId);
            var userBasket = await _basketRepository.GetAsync(lesseeId);
            //var anonymousUserBasket = await _basketRepository.GetAsync(anonymousUserId.Value);
            return await GetBasketDtoAsync(userBasket);
        }

        public async Task<CartDto> AddBagAsync(AddBagDto input)
        {
            //Guid userId = new Guid(input.LesseeId);

            var basket = await _basketRepository.GetAsync(input.LesseeId);
            //var product = await _basketProductService.GetAsync(input.ProductId);

            //if (basket.GetProductCount(product.Id) >= product.StockCount)
            //{
            //    throw new UserFriendlyException("There is not enough product in stock, sorry :(");
            //}

            basket.AddProduct(input.BagId, input.RenterId, input.BagName, input.Price, input.StartDate, input.EndDate, input.Tags);

            await _basketRepository.UpdateAsync(basket);

            return await GetBasketDtoAsync(basket);
        }

        public async Task<CartDto> RemoveBagAsync(RemoveBagDto input)
        {
            //Guid userId = new Guid(input.LesseeId);

            var basket = await _basketRepository.GetAsync(input.LesseeId);
            //var product = await _basketProductService.GetAsync(input.ProductId);
            basket.RemoveProduct(input.BagId, input.Count);
            await _basketRepository.UpdateAsync(basket);

            return await GetBasketDtoAsync(basket);
        }

        private async Task<CartDto> GetBasketDtoAsync(Basket basket)
        {
            var products = new Dictionary<Guid, CartDto>();
            var basketDto = new CartDto();
            var basketChanged = false;

            foreach (var basketItem in basket.Items)
            {
                var productDto = products.GetOrDefault(basketItem.BagId);

                basketDto.Items.Add(new CartItemDto
                {
                    BagId = basketItem.BagId,
                    BagName = basketItem.BagName,
                    RenterId = basketItem.RenterId,
                    price = basketItem.Price,
                    StartDate = basketItem.StartDate,
                    EndDate = basketItem.EndDate,
                    Tags = basketItem.Tags
                });
            }

            basketDto.TotalPrice = basketDto.Items.Sum(x => x.price);

            if (basketChanged)
            {
                await _basketRepository.UpdateAsync(basket);
            }

            return basketDto;
        }
    }

}
