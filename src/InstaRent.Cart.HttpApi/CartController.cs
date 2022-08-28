using InstaRent.Cart.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace InstaRent.Cart;

public abstract class CartController : AbpControllerBase
{
    protected CartController()
    {
        LocalizationResource = typeof(CartResource);
    }
}
