using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace InstaRent.Cart.Services
{
    public interface ICartAppService : IApplicationService
    {
        Task<CartDto> GetAsync(string lesseeId);
        Task<CartDto> AddBagAsync(AddBagDto input);
        Task<CartDto> RemoveBagAsync(RemoveBagDto input);
    }
}
