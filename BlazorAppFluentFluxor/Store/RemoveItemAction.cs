using BlazorAppFluentFluxor.Store.ShoppingCart;

namespace BlazorAppFluentFluxor.Store;

public record RemoveItemAction(CartItem ItemToRemove);
