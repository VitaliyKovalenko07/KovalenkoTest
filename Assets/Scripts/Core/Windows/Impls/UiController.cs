using Zenject;

namespace Core.Windows.Impls
{
	public abstract class UiController<TView> where TView : IUiView
	{
		[Inject] protected readonly TView View;
	}
}