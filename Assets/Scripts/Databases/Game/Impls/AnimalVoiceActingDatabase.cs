using System;
using Enums;
using Models;
using UnityEngine;

namespace Databases.Game.Impls
{
	[CreateAssetMenu(fileName = "AnimalVoiceActingDatabase", menuName = "Databases/Game/AnimalVoiceActingDatabase")]
	public class AnimalVoiceActingDatabase : ScriptableObject, IAnimalVoiceActingDatabase
	{
		[SerializeField] private AnimalVoiceActingVo[] animalVoiceActingVos;
		
		public void PlayAnimalVoiceByType(EAnimalType type)
		{
			foreach (var animalVoice in animalVoiceActingVos)
			{
				if (animalVoice.AnimalType == type)
					AudioSource.PlayClipAtPoint(animalVoice.AnimalStartAudio, Vector3.zero);
			}
		}
	}
}