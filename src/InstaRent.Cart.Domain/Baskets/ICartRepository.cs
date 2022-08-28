using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace InstaRent.Cart.Baskets
{
    public interface ICartRepository : IRepository
    {
        Task<Basket> GetAsync(string id);

        Task UpdateAsync(Basket cart);
    }
}
