using Ui.Factories.Impls;
using Zenject;

namespace Installers
{
	public class MenuInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<AnimalLevelFactory>().AsSingle();
		}
	}
}