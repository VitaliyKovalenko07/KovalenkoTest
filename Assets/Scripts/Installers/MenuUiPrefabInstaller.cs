using Core.Binding;
using Ui.Menu.Controllers.MainMenu.Impls;
using Ui.Menu.Views;
using Ui.Menu.Views.MainMenu;
using Ui.Menu.Views.MainMenu.Items;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
	[CreateAssetMenu(menuName = "Installers/MenuUiPrefabInstaller", fileName = "MenuUiPrefabInstaller")]
	public class MenuUiPrefabInstaller : ScriptableObjectInstaller
	{
		[Header("Canvas")] [SerializeField] private Canvas canvas;

		[Space] [SerializeField] private MainMenuView mainMenuView;
		[SerializeField] private MenuAnimalLevelItemView menuAnimalLevelItemView;
		
		public override void InstallBindings()
		{
			Container.Bind<CanvasScaler>().FromComponentInNewPrefab(canvas).AsSingle();
			var parent = Container.Resolve<CanvasScaler>().transform;

			Container.BindUiView<MainMenuController, MainMenuView>(mainMenuView, parent);
			Container.BindInstances(menuAnimalLevelItemView);
		}
	}
}