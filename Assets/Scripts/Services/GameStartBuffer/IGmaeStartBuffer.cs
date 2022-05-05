using Enums;

namespace Services.GameStartBuffer
{
	public interface IGameStartBuffer
	{
		EAnimalType CurrentAnimal { get; }
	}
}