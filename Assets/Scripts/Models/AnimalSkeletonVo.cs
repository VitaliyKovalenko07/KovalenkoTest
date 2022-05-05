using System;
using Enums;
using Spine;
using Spine.Unity;

namespace Models
{
	[Serializable]
	public class AnimalSkeletonVo
	{
		public EAnimalType AnimalType;
		public SkeletonDataAsset AnimalSkeleton;
	}
}