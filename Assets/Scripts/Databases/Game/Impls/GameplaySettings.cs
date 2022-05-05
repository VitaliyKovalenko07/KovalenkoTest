using UnityEngine;

namespace Databases.Game.Impls
{
	[CreateAssetMenu(fileName = "GameplaySettings", menuName = "Databases/Game/GameplaySettings")]
	public class GameplaySettings : ScriptableObject, IGameplaySettings
	{
		[SerializeField] private int timeToInactive;
		[SerializeField] private int timeToSleep;

		public int GetTimeToInactive => timeToInactive;
		public int GetTimeToSleep => timeToSleep;
	}
}