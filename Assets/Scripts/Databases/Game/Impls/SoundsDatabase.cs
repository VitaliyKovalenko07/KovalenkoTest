using Models;
using UnityEngine;

namespace Databases.Game.Impls
{
	[CreateAssetMenu(fileName = "SoundsDatabase", menuName = "Databases/Game/SoundsDatabase")]
	public class SoundsDatabase : ScriptableObject, ISoundsDatabase
	{
		[SerializeField] private AudioVo[] correctAudios;
		[SerializeField] private AudioVo[] incorrectAudios;

		private System.Random _random = new System.Random();
		
		public AudioClip GatRandomCorrectAudio => correctAudios[_random.Next(0, correctAudios.Length)].Audio;
		public AudioClip GetRandomIncorrectAudio => incorrectAudios[_random.Next(0, correctAudios.Length)].Audio;
	}
}