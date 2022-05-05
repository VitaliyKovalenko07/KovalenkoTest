using Models.Animation;
using UnityEngine;

namespace Databases.Game.Impls
{	
	[CreateAssetMenu(fileName = "AnimationParametersDatabase", menuName = "Databases/Game/AnimationParametersDatabase")]
	public class AnimationParametersDatabase : ScriptableObject, IAnimationParametersDatabase
	{
		[SerializeField] private TailAnimationParametersVo tailAnimationParameters;

		public TailAnimationParametersVo TailAnimationParameters => tailAnimationParameters;
	}
}