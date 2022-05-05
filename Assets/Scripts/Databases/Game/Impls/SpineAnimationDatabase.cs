using System;
using Enums;
using Models.Animation;
using UnityEngine;

namespace Databases.Game.Impls
{
	[CreateAssetMenu(fileName = "SpineAnimationDatabase", menuName = "Databases/Game/SpineAnimationDatabase")]
	public class SpineAnimationDatabase : ScriptableObject, ISpineAnimationDatabase
	{
		[SerializeField] private SpineAnimationVo[] spineAnimationVos;
		
		public SpineAnimationDataVo GetAnimationByType(EAnimalType animalType, EAnimationType animationType)
		{
			foreach (var animationInfo in spineAnimationVos)
			{
				if (animationInfo.AnimalType == animalType)
				{
					foreach (var animationData in animationInfo.SpineAnimationDataVos)
					{
						if (animationData.AnimationType == animationType)
						{
							return animationData;
						}
					}
				}
			}

			throw new Exception($"Cannot find animation info with types {animalType}, {animationType}");
		}
	}
}