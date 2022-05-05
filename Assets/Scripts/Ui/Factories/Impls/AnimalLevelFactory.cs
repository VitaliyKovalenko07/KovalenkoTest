using Ui.Menu.Views;
using Ui.Menu.Views.MainMenu.Items;
using Zenject;

namespace Ui.Factories.Impls
{
	public class AnimalLevelFactory : IAnimalLevelFactory
	{
		private readonly DiContainer _di;

		public AnimalLevelFactory(DiContainer di)
		{
			_di = di;
		}

		public MenuAnimalLevelItemView Create()
		{
			var view = _di.Resolve<MenuAnimalLevelItemView>();
			var go = _di.InstantiatePrefabForComponent<MenuAnimalLevelItemView>(view);
			return go;
		}
	}
}