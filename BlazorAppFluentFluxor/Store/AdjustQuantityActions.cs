using BlazorAppFluentFluxor.Store.ShoppingCart;

namespace BlazorAppFluentFluxor.Store;

public record IncreaseQuantityAction(CartItem item);
public record DecreaseQuantityAction(CartItem item);
