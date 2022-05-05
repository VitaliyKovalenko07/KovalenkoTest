using System;
using Enums;

namespace Models.Animation
{
	[Serializable]
	public class SpineAnimationDataVo
	{
		public EAnimationType AnimationType;
		public int TrackIndex;
		public string AnimationName;
	}
}