using Databases.Game;
using Databases.Game.Impls;
using UnityEngine;
using Zenject;

namespace Installers
{
	[CreateAssetMenu(menuName = "Installers/GameInstaller", fileName = "GameInstaller")]
	public class GameDatabaseInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private AnimalsSkeletonDatabase animalsSkeletonDatabase;
		[SerializeField] private AnimalTailsDatabase animalTailsDatabase;
		[SerializeField] private AnimalVoiceActingDatabase animalVoiceActingDatabase;
		[SerializeField] private AnimationParametersDatabase animationParametersDatabase;
		[SerializeField] private SoundsDatabase soundsDatabase;
		[SerializeField] private SpineAnimationDatabase spineAnimationDatabase;
		[SerializeField] private GameplaySettings gameplaySettings;

		public override void InstallBindings()
		{
			Container.Bind<IAnimalsSkeletonDatabase>().FromInstance(animalsSkeletonDatabase).AsSingle();
			Container.Bind<IAnimalTailsDatabase>().FromInstance(animalTailsDatabase).AsSingle();
			Container.Bind<IAnimalVoiceActingDatabase>().FromInstance(animalVoiceActingDatabase).AsSingle();
			Container.Bind<IAnimationParametersDatabase>().FromInstance(animationParametersDatabase).AsSingle();
			Container.Bind<ISoundsDatabase>().FromInstance(soundsDatabase).AsSingle();
			Container.Bind<ISpineAnimationDatabase>().FromInstance(spineAnimationDatabase).AsSingle();
			Container.Bind<IGameplaySettings>().FromInstance(gameplaySettings).AsSingle();
		}
	}
}