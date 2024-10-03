using BlazorAppFluentFluxor.Store;
using BlazorAppFluentFluxor.Store.Shop;
using BlazorAppFluentFluxor.Store.ShoppingCart;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Net.Http.Json;


namespace BlazorAppFluentFluxor.Pages
{
    public partial class Shop
    {
        [Inject]
        private IState<ShoppingCartState> CartState { get; set; }

		[Inject]
		private IState<ShopState> ShopState { get; set; }

		[Inject]
        public IDispatcher Dispatcher { get; set; }

        JustifyContent Justification = JustifyContent.FlexStart;
        int Spacing = 5;

		protected override async Task OnInitializedAsync()
		{
			
		}

        private void AddItemToCart(ShopItem item)
        {
            var action = new AddNewItemAction(new CartItem(item.Id, 1));
            Dispatcher.Dispatch(action);
        }
    }
}