using Core.Windows.Impls;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Menu.Views.MainMenu.Items
{
    public class MenuAnimalLevelItemView : UiView
    {
        [SerializeField] private Image animalIcon;
        [SerializeField] private Button levelButton;

        public Button LevelButton => levelButton;
        
        public void SetAnimalIcon(Sprite animalSprite) => animalIcon.sprite = animalSprite;
    }
}
