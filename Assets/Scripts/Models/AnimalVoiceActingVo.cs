using System;
using Enums;
using UnityEngine;

namespace Models
{
	[Serializable]
	public class AnimalVoiceActingVo
	{
		public EAnimalType AnimalType;
		public AudioClip AnimalStartAudio;
	}
}