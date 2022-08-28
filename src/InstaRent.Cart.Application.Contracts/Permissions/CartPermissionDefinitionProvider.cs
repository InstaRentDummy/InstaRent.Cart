using InstaRent.Cart.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace InstaRent.Cart.Permissions;

public class CartPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CartPermissions.GroupName, L("Permission:Cart"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CartResource>(name);
    }
}
