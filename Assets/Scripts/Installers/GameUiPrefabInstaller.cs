using Core.Binding;
using Ui.Game.Controllers.Impls;
using Ui.Game.Views;
using Ui.Game.Views.Items;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
	[CreateAssetMenu(menuName = "Installers/GameUiPrefabInstaller", fileName = "GameUiPrefabInstaller")]
	public class GameUiPrefabInstaller : ScriptableObjectInstaller
	{
		[Header("Canvas")] [SerializeField] private Canvas canvas;

		[Space] [SerializeField] private GameplayView gameplayView;
		[SerializeField] private AnimalTailItemView animalTailItemView;

		public override void InstallBindings()
		{
			Container.Bind<CanvasScaler>().FromComponentInNewPrefab(canvas).AsSingle();
			var parent = Container.Resolve<CanvasScaler>().transform;

			Container.BindUiView<GameplayController, GameplayView>(gameplayView, parent);
			Container.BindInstances(animalTailItemView);
		}
	}
}