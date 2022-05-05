using System;
using Core.Windows.Impls;
using Databases.Menu;
using Enums;
using Signals;
using Ui.Menu.Views.MainMenu;
using UniRx;
using UnityEngine.SceneManagement;
using Zenject;

namespace Ui.Menu.Controllers.MainMenu.Impls
{
	public class MainMenuController : UiController<MainMenuView>, IMainMenuController, IInitializable, IDisposable
	{
		private readonly IAnimalsIconsDatabase _animalsIconsDatabase;
		private readonly SignalBus _signalBus;

		public MainMenuController
		(
			IAnimalsIconsDatabase animalsIconsDatabase,
			SignalBus signalBus
		)
		{
			_animalsIconsDatabase = animalsIconsDatabase;
			_signalBus = signalBus;
		}

		public void Initialize()
		{
			SetGameLevels();
		}

		public void Dispose()
		{
			
		}

		private void SetGameLevels()
		{
			foreach (var levelInfo in _animalsIconsDatabase.GetAnimalInfos)
			{
				var itemView = View.MenuAnimalLevelItemCollection.CreateItem();
				itemView.SetAnimalIcon(levelInfo.AnimalIcon);
				itemView.LevelButton.OnClickAsObservable().Subscribe(_ => OnLevelClick(levelInfo.AnimalType));
			}
		}

		private void OnLevelClick(EAnimalType type)
		{
			SceneManager.LoadScene("GameScene");
			_signalBus.Fire(new SignalGameSelect(type));
		}
	}
}