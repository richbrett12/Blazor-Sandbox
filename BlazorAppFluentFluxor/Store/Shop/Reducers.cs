using BlazorAppFluentFluxor.Store.ShoppingCart;
using Fluxor;

namespace BlazorAppFluentFluxor.Store.Shop;

public static class Reducers
{
	[ReducerMethod]
	public static ShopState ReduceAddItemToShopAction(ShopState state, AddItemToShopAction action) => state with
	{
		CurrentShopItems = state.CurrentShopItems.Append(action.NewItem)
	};

	[ReducerMethod]
	public static ShopState ReduceRemoveItemFromShopAction(ShopState state, RemoveItemFromShopAction action) => state with
	{
		CurrentShopItems = state.CurrentShopItems.Where(item => item.Id != action.NewItem.Id)
	};

	[ReducerMethod]
	public static ShopState ReduceUpdateItemInShopAction(ShopState state, UpdateItemInShopAction action) => state with
	{
		CurrentShopItems = state.CurrentShopItems.Where(item => item.Id != action.NewItem.Id).Append(action.NewItem)
	};

}
