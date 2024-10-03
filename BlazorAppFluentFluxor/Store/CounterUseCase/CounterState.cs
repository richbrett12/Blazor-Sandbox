using Fluxor;

namespace BlazorAppFluentFluxor.Store.CounterUseCase
{
	[FeatureState]
	public class CounterState
	{
		public int ClickCount { get; }

		private CounterState() { }

		public CounterState(int clickCount)
		{
			this.ClickCount = clickCount;
		}
	}
}
