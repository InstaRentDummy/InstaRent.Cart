using InstaRent.Cart.Localization;
using Volo.Abp.Application.Services;

namespace InstaRent.Cart;

public abstract class CartAppService : ApplicationService
{
    protected CartAppService()
    {
        LocalizationResource = typeof(CartResource);
        ObjectMapperContext = typeof(CartApplicationModule);
    }
}
