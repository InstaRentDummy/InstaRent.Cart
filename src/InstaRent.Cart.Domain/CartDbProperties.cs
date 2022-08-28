namespace InstaRent.Cart;

public static class CartDbProperties
{
    public static string DbTablePrefix { get; set; } = "Cart";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Cart";
}
