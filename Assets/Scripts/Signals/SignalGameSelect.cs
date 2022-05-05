using Enums;

namespace Signals
{
	public class SignalGameSelect
	{
		public EAnimalType AnimalType;
		
		public SignalGameSelect(EAnimalType type)
		{
			AnimalType = type;
		}
	}
}