using BlazorAppFluentFluxor.Store.ShoppingCart;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorAppFluentFluxor.Layout
{
	public partial class ShoppingCartLink
	{
		[Inject]
		public required IState<ShoppingCartState> ShoppingCartState { get; set; }

		//protected override void OnInitialized()
		//{
		//	base.OnInitialized();
		//}

		//private void RefreshMe()
		//{
		//	StateHasChanged();
		//}
	}
}