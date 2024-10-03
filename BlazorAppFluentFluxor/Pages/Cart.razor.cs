using BlazorAppFluentFluxor.Store;
using BlazorAppFluentFluxor.Store.Shop;
using BlazorAppFluentFluxor.Store.ShoppingCart;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlazorAppFluentFluxor.Pages;

public partial class Cart
{
	[Inject]
	private IState<ShoppingCartState> ShoppingCartState { get; set; }
	[Inject]
	private IState<ShopState> ShopState { get; set; }

	[Inject]
	public IDispatcher Dispatcher { get; set; }

	private int MaxItemQuantity { get; init; } = 10;

	private void RemoveFromCart(CartItem item)
	{
		var action = new RemoveItemAction(item);
		Dispatcher.Dispatch(action);
	}

	private void IncreaseQuantity(CartItem item)
	{
		var action = new IncreaseQuantityAction(item);
		Dispatcher.Dispatch(action);
	}

	private void DecreaseQuantity(CartItem item)
	{
		var action = new DecreaseQuantityAction(item);
		Dispatcher.Dispatch(action);
	}

}