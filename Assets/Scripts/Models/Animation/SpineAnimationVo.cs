using System;
using Enums;

namespace Models.Animation
{
	[Serializable]
	public class SpineAnimationVo
	{
		public EAnimalType AnimalType;
		public SpineAnimationDataVo[] SpineAnimationDataVos;
	}
}