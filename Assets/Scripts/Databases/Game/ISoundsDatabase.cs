using UnityEngine;

namespace Databases.Game
{
	public interface ISoundsDatabase
	{
		AudioClip GatRandomCorrectAudio { get; }
		AudioClip GetRandomIncorrectAudio { get; }
	}
}