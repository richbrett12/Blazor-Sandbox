using Fluxor;
using Microsoft.AspNetCore.Components;
using BlazorAppFluentFluxor.Store.CounterUseCase;
using BlazorAppFluentFluxor.Store;

namespace BlazorAppFluentFluxor.Pages
{
	public partial class Counter
	{
		[Inject]
		private IState<CounterState> CounterState { get; set; }

		[Inject]
		public IDispatcher Dispatcher { get; set; }	

		private void IncrementCount()
		{
			var action = new IncrementCounterAction();
			Dispatcher.Dispatch(action);
		}
	}
}