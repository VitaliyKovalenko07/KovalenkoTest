using Core.Windows.Impls;
using DG.Tweening;
using Models.Animation;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Game.Views.Items
{
	public class AnimalTailItemView : UiView
	{
		[SerializeField] private Image tailImage;
		[SerializeField] private Image helpFingerImage;
		[SerializeField] private Outline tailOutline;
		[SerializeField] private Button tailButton;

		private Tween scalingTween;
		private Tween internalTween;
		
		public Button TailButton => tailButton;
		public Outline TailOutline => tailOutline;

		public void SetAnimalTail(Sprite tail) => tailImage.sprite = tail;

		public void SetActiveHelpFinger(bool isActive) => helpFingerImage.enabled = isActive;

		public void StartTailAnimation(TailAnimationParametersVo animationParms, bool isInactive)
		{
			if (isInactive)
				StartAnimation(animationParms);

			else
			{
				scalingTween.Kill();
				internalTween.Kill();
				transform.DOScale(animationParms.StartScale, animationParms.Duration);
			}
		}
		
		private void StartAnimation(TailAnimationParametersVo animationParms)
		{
			scalingTween =
			transform.DOScale(animationParms.EndScale, animationParms.Duration).OnComplete(() =>
			{
				internalTween = transform.DOScale(animationParms.StartScale, animationParms.Duration)
					.OnComplete(() => StartAnimation(animationParms));
			});
		}
	}
}