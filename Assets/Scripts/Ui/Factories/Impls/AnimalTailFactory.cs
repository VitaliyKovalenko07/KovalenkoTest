using Ui.Game.Views.Items;
using Zenject;

namespace Ui.Factories.Impls
{
	public class AnimalTailFactory : IAnimalTailFactory
	{
		private readonly DiContainer _di;

		public AnimalTailFactory(DiContainer di)
		{
			_di = di;
		}

		public AnimalTailItemView Create()
		{
			var view = _di.Resolve<AnimalTailItemView>();
			var go = _di.InstantiatePrefabForComponent<AnimalTailItemView>(view);
			return go;
		}
	}
}