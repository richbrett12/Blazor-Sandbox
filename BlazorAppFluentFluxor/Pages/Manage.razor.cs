using BlazorAppFluentFluxor.Store;
using BlazorAppFluentFluxor.Store.Shop;
using Fluxor;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace BlazorAppFluentFluxor.Pages;

public partial class Manage
{
	[Inject]
	private IState<ShopState> ShopState { get; set; }
	[Inject]
	public IDispatcher Dispatcher { get; set; }
	[Inject]
	public NavigationManager NavigationManager { get; set; }

	//List<ManagerShopItem> ShopItems { get; set; } = [];

	private bool ShowAddItemForm { get; set; } = false;

	[SupplyParameterFromForm]
	private FormNewShopItem newFormItem { get; set; } = new();

	//private string? newItemName {  get; set; }
	//private string? newItemCost {  get; set; }
	//private string? newItemDescription {  get; set; }

	private async void PopulateSampleStoreItems()
	{
		var CurrentShopItems = (await Http.GetFromJsonAsync<List<ShopItem>>("sample-data/store.json"))!.AsQueryable();
		foreach (var item in CurrentShopItems)
		{
			Dispatcher.Dispatch(new AddItemToShopAction(item));
		}
	}

	private void AddNewItemToStore()
	{
		if (newFormItem.newItemName != null && newFormItem.newItemCost != null && newFormItem.newItemDescription != null)
		{
			var guid = Guid.NewGuid().ToString();
			var newItem = new ShopItem(guid, newFormItem.newItemName, newFormItem.newItemCost, newFormItem.newItemDescription);
			var action = new AddItemToShopAction(newItem);
			Dispatcher.Dispatch(action);
			newFormItem = new();
			ShowAddItemForm = false;
		}
		//NavigationManager.NavigateTo("/manage");
	}

	private void RemoveItemFromStore(ShopItem itemToRemove)
	{
		var action = new RemoveItemFromShopAction(itemToRemove);
		Dispatcher.Dispatch(action);
	}

	private void UpdateItem(ManagerShopItem updatedItem)
	{
		ShopItem updatedShopItem = new(updatedItem.id, updatedItem.name, updatedItem.cost, updatedItem.description);
		var action = new UpdateItemInShopAction(updatedShopItem);
		Dispatcher.Dispatch(action);
	}

}

public class ManagerShopItem(string id, string name, string cost, string description)
{
	public string id = id;
	public string name = name;
	public string cost = cost;
	public string description = description;
}

public class FormNewShopItem
{
	[Required]
	public string? newItemName { get; set; }
	[Required]
	public string? newItemCost { get; set; }
	[Required]
	public string? newItemDescription { get; set; }
}