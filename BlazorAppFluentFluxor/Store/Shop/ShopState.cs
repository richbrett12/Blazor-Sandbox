using BlazorAppFluentFluxor.Store.ShoppingCart;
using Fluxor;

namespace BlazorAppFluentFluxor.Store.Shop;

public record ShopItem(string Id, string Name, string Cost, string Description);
public record ShopState(IEnumerable<ShopItem> CurrentShopItems);

public class ShopFeatureState : Feature<ShopState>
{
	public override string GetName() => nameof(ShopState);
	protected override ShopState GetInitialState() => new([]);
}
