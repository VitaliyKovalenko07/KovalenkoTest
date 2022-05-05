using Databases.Menu;
using Databases.Menu.Impls;
using UnityEngine;
using Zenject;

namespace Installers
{
	[CreateAssetMenu(menuName = "Installers/MenuInstaller", fileName = "MenuInstaller")]
	public class MenuDatabaseInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private AnimalsIconsDatabase animalsIconsDatabase;
		public override void InstallBindings()
		{
			Container.Bind<IAnimalsIconsDatabase>().FromInstance(animalsIconsDatabase).AsSingle();
		}
	}
}