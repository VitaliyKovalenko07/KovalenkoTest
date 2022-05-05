using Enums;
using Models;
using Models.Animation;

namespace Databases.Game
{
	public interface ISpineAnimationDatabase
	{
		SpineAnimationDataVo GetAnimationByType(EAnimalType animalType, EAnimationType animationType);
	}
}