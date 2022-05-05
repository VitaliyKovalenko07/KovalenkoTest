using Models;

namespace Databases.Game
{
	public interface IAnimalTailsDatabase
	{
		AnimalTailVo[] GetAnimalTailIfo { get; }
	}
}