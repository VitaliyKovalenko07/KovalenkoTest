using Enums;
using UnityEngine;

namespace Databases.Game
{
	public interface IAnimalVoiceActingDatabase
	{
		void PlayAnimalVoiceByType(EAnimalType type);
	}
}