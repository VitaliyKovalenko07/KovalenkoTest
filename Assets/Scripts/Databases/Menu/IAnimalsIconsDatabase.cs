using Enums;
using Models;

namespace Databases.Menu
{
	public interface IAnimalsIconsDatabase
	{
		AnimalVo[] GetAnimalInfos { get; }
		AnimalVo GetAnimalByType(EAnimalType type);
	}
}