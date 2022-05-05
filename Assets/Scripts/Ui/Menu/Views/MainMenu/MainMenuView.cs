using Core.Windows;
using Core.Windows.Impls;
using Ui.Menu.Views.MainMenu.Collections;
using UnityEngine;

namespace Ui.Menu.Views.MainMenu
{
	public class MainMenuView : UiView
	{
		[SerializeField] private MenuAnimalLevelItemCollection menuAnimalLevelItemCollection;

		public MenuAnimalLevelItemCollection MenuAnimalLevelItemCollection => menuAnimalLevelItemCollection;
	}
}