using InstaRent.Cart.Baskets;
using System.Threading.Tasks;
using Volo.Abp.Caching;

namespace InstaRent.Cart.Entities
{
    public class CartRepository : ICartRepository
    {
        private readonly IDistributedCache<Basket, string> _cache;

        public CartRepository(IDistributedCache<Basket, string> cache)
        {
            _cache = cache;
        }

        public async Task<Basket> GetAsync(string id)
        {
            return await _cache.GetOrAddAsync(id, () => Task.FromResult(new Basket(id)));
        }

        public async Task UpdateAsync(Basket cart)
        {
            await _cache.SetAsync(cart.Id, cart);
        }
    }
}
