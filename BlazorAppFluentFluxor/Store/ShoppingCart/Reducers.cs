using Fluxor;

namespace BlazorAppFluentFluxor.Store.ShoppingCart;

public static class Reducers
{
	[ReducerMethod]
	public static ShoppingCartState ReduceAddNewItemAction(ShoppingCartState state, AddNewItemAction action) => state with
	{
		CartItems = state.CartItems.Append(action.NewItem).OrderBy(i => i.id),
		CartCount = state.CartCount + 1
	};

	[ReducerMethod]
	public static ShoppingCartState ReduceRemoveItemAction(ShoppingCartState state, RemoveItemAction action) => state with
	{
		CartItems = state.CartItems.Where(i => i != action.ItemToRemove),
		CartCount = state.CartCount - 1
	};

	[ReducerMethod]
	public static ShoppingCartState ReduceIncreaseQuantityAction(ShoppingCartState state, IncreaseQuantityAction action)
	{
		var newItem = action.item with
		{
			quantity = action.item.quantity + 1
		};

		return state with
		{
			CartItems = state.CartItems.Where(i => i != action.item).Append(newItem).OrderBy(i => i.id),
		};
	}

	[ReducerMethod]
	public static ShoppingCartState ReduceDecreaseQuantityAction(ShoppingCartState state, DecreaseQuantityAction action)
	{
		if (action.item.quantity > 1)
		{
			var newItem = action.item with
			{
				quantity = action.item.quantity - 1
			};

			return state with
			{
				CartItems = state.CartItems.Where(i => i != action.item).Append(newItem).OrderBy(i => i.id),
			};
		}
		else
		{
			return state;
		}

	}
}
