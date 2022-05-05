using System;
using Core.Windows.Impls;
using Models.Animation;
using Spine;
using Spine.Unity;
using Ui.Game.Views.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Game.Views
{
	public class GameplayView : UiView
	{
		[SerializeField] private LeftPanelTailsCollection leftPanelTailsCollection;
		[SerializeField] private RightPanelTailsCollection rightPanelTailsCollection;
		[SerializeField] private SkeletonGraphic animalSkeleton;
		[SerializeField] private Button backButton;
		[SerializeField] private Button animalButton;

		public LeftPanelTailsCollection LeftPanelTailsCollection => leftPanelTailsCollection;
		public RightPanelTailsCollection RightPanelTailsCollection => rightPanelTailsCollection;
		public Button BackButton => backButton;
		public Button AnimalButton => animalButton;

		public void SetAnimalSkeleton(SkeletonDataAsset skeleton)
		{
			animalSkeleton.skeletonDataAsset = skeleton;
			animalSkeleton.gameObject.SetActive(true);
			animalSkeleton.enabled = true;
		}

		public void StartSkeletonAnimation(SpineAnimationDataVo animationParms, bool isLoop)
		{
			var spineAnimation = animalSkeleton.AnimationState.SetAnimation(animationParms.TrackIndex,
				animationParms.AnimationName,
				isLoop);

			if (!isLoop)
				StaratIdleAnimation(spineAnimation.Animation.Duration);
		}

		public void StartSkeletonAnimation(SpineAnimationDataVo animationParms, bool isLoop, Action onAnimationComplete,
			float actionDelay)
		{
			var spineAnimation = animalSkeleton.AnimationState.SetAnimation(animationParms.TrackIndex,
				animationParms.AnimationName,
				isLoop);

			Observable.Timer(TimeSpan.FromSeconds(actionDelay))
				.Subscribe(_ => onAnimationComplete?.Invoke());

			if (!isLoop)
				StaratIdleAnimation(spineAnimation.Animation.Duration);
		}

		private void StaratIdleAnimation(float animationDelay) => Observable
			.Timer(TimeSpan.FromSeconds(animationDelay))
			.Subscribe(_ => animalSkeleton.AnimationState.SetAnimation(0,
				"Idle",
				true));
	}
}