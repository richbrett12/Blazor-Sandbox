using BlazorAppFluentFluxor.Store;
using BlazorAppFluentFluxor.Store.Shop;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlazorAppFluentFluxor.Pages;

public partial class Edit
{
	[Inject]
	private IState<ShopState> ShopState { get; set; }

	[Inject]
	public IDispatcher Dispatcher { get; set; }

	List<ManagerShopItem> ShopItems { get; set; } = [];
	private bool ShopItemsLoaded { get; set; } = false;

	protected override async Task OnInitializedAsync()
	{
		ShopItemsLoaded = false;
		foreach (var item in ShopState.Value.CurrentShopItems)
		{
			var newItem = new ManagerShopItem(item.Id, item.Name, item.Cost, item.Description);
			ShopItems.Add(newItem);
		}
		ShopItemsLoaded = true;
	}

	private bool isEqual(ManagerShopItem editedItem)
	{
		var existingItem = ShopState.Value.CurrentShopItems.First(i => i.Id == editedItem.id);
		if (existingItem.Name == editedItem.name && existingItem.Cost == editedItem.cost && existingItem.Description == editedItem.description)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private void UpdateItem(ManagerShopItem updatedItem)
	{
		ShopItem updatedShopItem = new(updatedItem.id, updatedItem.name, updatedItem.cost, updatedItem.description);
		var action = new UpdateItemInShopAction(updatedShopItem);
		Dispatcher.Dispatch(action);
	}

}