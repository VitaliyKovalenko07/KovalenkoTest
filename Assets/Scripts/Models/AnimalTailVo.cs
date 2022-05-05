using System;
using Enums;
using UnityEngine;

namespace Models
{
	[Serializable]
	public class AnimalTailVo
	{
		public EAnimalType AnimalType;
		public EPanelType PanelType;
		public Sprite AnimalTail;
		public Vector2 SpawnPlace;
	}
}