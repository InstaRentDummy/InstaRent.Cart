using Volo.Abp.Reflection;

namespace InstaRent.Cart.Permissions;

public class CartPermissions
{
    public const string GroupName = "Cart";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CartPermissions));
    }
}
