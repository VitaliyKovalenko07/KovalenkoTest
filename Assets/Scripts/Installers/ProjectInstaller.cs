using Services.GameStartBuffer;
using Services.GameStartBuffer.Impls;
using Signals;
using Zenject;

namespace Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			SignalBusInstaller.Install(Container);
			
			Container.BindInterfacesAndSelfTo<GameStartBuffer>().AsSingle();
			Container.DeclareSignal<SignalGameSelect>();
		}
	}
}