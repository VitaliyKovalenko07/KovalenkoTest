using Ui.Factories.Impls;
using Zenject;

namespace Installers
{
	public class GameInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<AnimalTailFactory>().AsSingle();
		}
	}
}