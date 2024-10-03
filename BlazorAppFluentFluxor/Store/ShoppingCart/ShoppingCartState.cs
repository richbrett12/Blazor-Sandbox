using Fluxor;

namespace BlazorAppFluentFluxor.Store.ShoppingCart;

public record CartItem(string id, int quantity);

public record ShoppingCartState(IEnumerable<CartItem> CartItems, int CartCount);

public class ShoppingCartFeatureState : Feature<ShoppingCartState>
{
	public override string GetName() => nameof(ShoppingCartState);
	protected override ShoppingCartState GetInitialState() => new([], 0);
}