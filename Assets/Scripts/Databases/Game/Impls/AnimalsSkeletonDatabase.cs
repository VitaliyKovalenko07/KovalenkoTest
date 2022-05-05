using System;
using Enums;
using Models;
using Spine.Unity;
using UnityEngine;

namespace Databases.Game.Impls
{
	[CreateAssetMenu(fileName = "AnimalsSkeletonDatabase", menuName = "Databases/Game/AnimalsSkeletonDatabase")]
	public class AnimalsSkeletonDatabase : ScriptableObject, IAnimalsSkeletonDatabase
	{
		[SerializeField] private AnimalSkeletonVo[] animalSkeletonVos;
		
		public SkeletonDataAsset GetSkeletonByType(EAnimalType animalType)
		{
			foreach (var animalSkeletonVo in animalSkeletonVos)
			{
				if (animalSkeletonVo.AnimalType == animalType)
					return animalSkeletonVo.AnimalSkeleton;
			}
			
			throw new Exception($"Cannot find skeleton with type: {animalType}");
		}
	}
}