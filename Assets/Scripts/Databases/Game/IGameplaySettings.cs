namespace Databases.Game
{
	public interface IGameplaySettings
	{
		int GetTimeToInactive { get; }
		int GetTimeToSleep { get; }
	}
}