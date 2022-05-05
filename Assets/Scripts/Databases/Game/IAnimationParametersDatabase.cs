using Models.Animation;

namespace Databases.Game
{
	public interface IAnimationParametersDatabase
	{
		TailAnimationParametersVo TailAnimationParameters { get; }
	}
}