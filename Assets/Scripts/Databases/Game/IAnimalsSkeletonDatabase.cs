using Enums;
using Spine.Unity;

namespace Databases.Game
{
	public interface IAnimalsSkeletonDatabase
	{
		SkeletonDataAsset GetSkeletonByType(EAnimalType animalType);
	}
}